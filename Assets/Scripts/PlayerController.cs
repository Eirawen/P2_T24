using UnityEngine;


public class PlayerController : MonoBehaviour {
    public float speed = 5.0f; // how fast the player moves by default
    public float jumpForce = 6.0f; // how high the player jumps
    public float movementSmooth = 0.1f; // how smooth the movement is, play around with this value
    public float groundCheckDistance = 0.6f; // how far down to check for ground
    public float airControl = 0.9f; // how much control the player has in the air
    public float normalGravityScale = 1.0f; // how much gravity affects the player
    public LayerMask groundLayer; //defines the ground layer - useful for checking collision with the ground
    protected Rigidbody2D rb; // rigidbody2d is the unity physics component that allows the player to move
    protected Vector2 velocitySmooth = Vector2.zero; // smooths out the movement
    public bool isPlayerGrounded; // checks if the player is on the ground
    public bool isPlayerMoving; // checks if the player is moving

    protected float moveInput; // stores the player's input for movement
    protected float moveInputX;
    protected float moveInputY;

    public static bool catFormUnlocked; 
    public static bool salmonFormUnlocked;
    public static bool humanFormUnlocked; 

    public Sprite[] Sprites; // stores the player's sprites
    public Sprite currentSprite; // stores the player's current sprite

    public static Vector2 lastCheckPointPos;



    protected virtual void Awake() { // called when the script is first initialized
        DontDestroyOnLoad(this.gameObject); // keeps the player persistent between scenes
        rb = gameObject.GetComponent<Rigidbody2D>();
        if (rb == null) {
            rb = gameObject.AddComponent<Rigidbody2D>();
            Debug.LogWarning("Rigidbody2d component not found, adding one automatically");
            
        }
        groundLayer = LayerMask.GetMask("Ground");
        gameObject.tag = "Player";
    }
    void Start() { // called when the script is first initialized
        
    }

    protected virtual void Update() { // called every frame
        if (DialogueManager.Instance != null && DialogueManager.Instance.isDialogueActive)
        {
            moveInput = 0f;
            rb.velocity = Vector2.zero; // Immediately stop the player's movement
            return;
        }


        if (PasswordTrigger.Instance != null && PasswordTrigger.Instance.isSolving)
        {
            // If the player is currently solving the password, stop the player's movement
            moveInput = 0f;
            rb.velocity = Vector2.zero;
            return;
        }

        // If "p" is pressed, respawn to checkpoint. Will change to on death + menu click later
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Respawn!");
            returnToCheckpoint();
        }

    }

    protected virtual void MovePlayer() { // defines player movement
        float x = moveInputX * speed;
                                            //So, the reason we can't do this here, is because Unity throws a bunch of errors when accessing the sprite array.
                                           // what we want to do generally is keep all of the form specific movement in the child class, so we know its only active for that class. 


        Vector2 targetVelocity = new Vector2(x, rb.velocity.y);
        isPlayerGrounded = isGrounded();

        if (isPlayerGrounded) { 
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocitySmooth, movementSmooth);
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

    protected bool isGrounded() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        return hit.collider != null;
    }


    public bool isMoving() {
        isPlayerGrounded = isGrounded();
        return rb.velocity.x != 0 || !isPlayerGrounded ;
    }


    public virtual void SwitchSprite() {

    }

    public void returnToCheckpoint()

    {
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }
}





