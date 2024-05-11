using UnityEngine;

public class SlimeMovement : MonoBehaviour {
    public float speed = 5.0f; // how fast the player moves by default
    public float jumpForce = 10.0f; // how high the player jumps
    public float movementSmooth = 0.1f; // how smooth the movement is, play around with this value
    public float groundCheckDistance = 0.1f; // how far down to check for ground
    public float airControl = 0.3f; // how much control the player has in the air
    public LayerMask groundLayer; //defines the ground layer - useful for checking collision with the ground
    private Rigidbody2D rb; // rigidbody2d is the unity physics component that allows the player to move
    private Vector2 velocitySmooth; // smooths out the movement
    public bool isGrounded; // checks if the player is on the ground

    private float moveInput; // stores the player's input for movement

    void Start() { // called when the script is first initialized
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) {
            rb = gameObject.AddComponent<Rigidbody2D>();
            Debug.LogWarning("Rigidbody2d component not found, adding one automatically");
        }
    }

    void Update() { // called every frame
        moveInput = Input.GetAxis("Horizontal");
        MovePlayer(); 
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    void MovePlayer() { // defines player movement
        Vector2 targetVelocity = new Vector2(moveInput * speed, rb.velocity.y);
        isGrounded = IsGrounded();

        if (isGrounded) {
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocitySmooth, movementSmooth);
        } else {
            targetVelocity *= airControl;
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocitySmooth, movementSmooth * airControl);
        }
    }

    void Jump() {
        if (isGrounded) {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    bool IsGrounded() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }



    // might want a collision check visualizer if it shows prudent. 








    //Things to add:
    //Maybe put all collision for walls in here, I dont know if it works the same as 3d. 
    //Add a check for the player to be able to jump off walls? 
    //currently probably doesn't handle slopes very well.
    //add a platform layer

}





