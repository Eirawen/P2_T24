using UnityEngine;


public class PlayerController : MonoBehaviour {
    public float speed = 5.0f; // how fast the player moves by default
    public float jumpForce = 6.0f; // how high the player jumps
    public float movementSmooth = 0.1f; // how smooth the movement is, play around with this value
    public float groundCheckDistance = 0.6f; // how far down to check for ground
    public float airControl = 0.9f; // how much control the player has in the air
    public LayerMask groundLayer; //defines the ground layer - useful for checking collision with the ground
    protected Rigidbody2D rb; // rigidbody2d is the unity physics component that allows the player to move
    private Vector2 velocitySmooth; // smooths out the movement
    public bool isPlayerGrounded; // checks if the player is on the ground
    public bool isPlayerMoving; // checks if the player is moving

    protected float moveInput; // stores the player's input for movement
    protected float moveInputX;
    protected float moveInputY;

    public Sprite[] Sprites; // stores the player's sprites
    public Sprite currentSprite; // stores the player's current sprite


    protected virtual void Awake() { // called when the script is first initialized
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start() { // called when the script is first initialized

        rb = GetComponent<Rigidbody2D>();
        if (rb == null) {
            rb = gameObject.AddComponent<Rigidbody2D>();
            Debug.LogWarning("Rigidbody2d component not found, adding one automatically");
        }

        groundLayer = LayerMask.GetMask("Ground");
        gameObject.tag = "Player";
        currentSprite = Sprites[0];


    }

    protected virtual void Update() { // called every frame
        moveInput = Input.GetAxis("Horizontal");
        MovePlayer(); 
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Jump");
            Jump();
        }
    }

    protected virtual void MovePlayer() { // defines player movement
        float x = moveInputX * speed;
        float y = rb.velocity.y;
        if (currentSprite == Sprites[1]) { // fish can swim up/down too
            y = moveInputY * speed;
        }

        Vector2 targetVelocity = new Vector2(x, y);
        isPlayerGrounded = isGrounded();

        if (isPlayerGrounded) {
            if (currentSprite == Sprites[0]) { // slime
                rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocitySmooth, movementSmooth);
            } else {
                rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocitySmooth, movementSmooth);
            }
        } else {
            targetVelocity *= airControl;   
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocitySmooth, movementSmooth * airControl);
        }
    }

    protected virtual void Jump() {
        isPlayerGrounded = isGrounded();
        if (isPlayerGrounded) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool isGrounded() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }


    public bool isMoving() {
        isPlayerGrounded = isGrounded();
        return rb.velocity.x != 0 || !isPlayerGrounded ;
    }


    public virtual void SwitchSprite() {

    }



    // might want a collision check visualizer if it shows prudent. 








    //Things to add:
    //Maybe put all collision for walls in here, I dont know if it works the same as 3d. 
    //Add a check for the player to be able to jump off walls? 
    //currently probably doesn't handle slopes very well.
    //add a platform layer

}





