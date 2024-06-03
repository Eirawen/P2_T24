using UnityEngine;


public class PlayerController : MonoBehaviour {
    public bool inWater = false; 
    public float speed = 5.0f; // how fast the player moves by default
    public float jumpForce = 6.0f; // how high the player jumps
    public float movementSmooth = 0.1f; // how smooth the movement is, play around with this value
    public float groundCheckDistance = 0.6f; // how far down to check for ground
    public float airControl = 0.9f; // how much control the player has in the air
    public float normalGravityScale = 1.0f; // how much gravity affects the player
    public LayerMask groundLayer; //defines the ground layer - useful for checking collision with the ground
    public LayerMask wallLayer; //defines the wall layer - useful for checking collision with the wall
    protected Rigidbody2D rb; // rigidbody2d is the unity physics component that allows the player to move
    protected Vector2 velocitySmooth = Vector2.zero; // smooths out the movement
    public bool isPlayerGrounded; // checks if the player is on the ground
    public bool isPlayerMoving; // checks if the player is moving
    protected Vector2 lastContactNormal;
    protected bool isFacingRight = true;

    public bool isWallSliding;
    public float wallSlideSpeed = 2f;

    public bool isWallJumping;
    public float wallJumpingDirection;
    public float wallJumpingTime = 0.2f; 
    public float wallJumpingCounter;
    public float wallJumpingDuration = 0.4f; 


    public Transform wallCheck;
    public Transform groundCheck;


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
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;  // no more flipping upside down
        groundLayer = LayerMask.GetMask("Ground", "Platform");
        wallLayer = LayerMask.GetMask("Platform");
        gameObject.tag = "Player";
        wallCheck = transform.Find("WallCheck");
        if (wallCheck == null) {
            GameObject wallCheckObject = new GameObject("WallCheck");
            wallCheckObject.transform.parent = transform;
            wallCheckObject.transform.localPosition = new Vector3(0.3f, 0, 0);
            wallCheck = wallCheckObject.transform;
        }
        groundCheck = transform.Find("GroundCheck");
        if (groundCheck == null) {
            GameObject groundCheckObject = new GameObject("GroundCheck");
            groundCheckObject.transform.parent = transform;
            groundCheckObject.transform.localPosition = new Vector3(0, -0.3f, 0);
            groundCheck = groundCheckObject.transform;
        }
    }
    void Start() { // called when the script is first initialized
        
    }

    protected virtual void Update() { // called every frame
        moveInputX = Input.GetAxisRaw("Horizontal");
        isPlayerGrounded = isGrounded();

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

        WallSlide();
        WallJump();


        if (!isWallJumping) {
            Flip();
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
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    public bool isMoving() {
        isPlayerGrounded = isGrounded();
        return rb.velocity.x > 0.1f || !isPlayerGrounded ;
    }


    public virtual void SwitchSprite() {

    }

    public void returnToCheckpoint()

    {
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }
    

    private bool isWalled() {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }   

    protected void WallSlide() {
        bool isWalledy = isWalled();
        if (isWalledy && !isPlayerGrounded) {
            isWallSliding = true;
            Debug.Log(isWalledy);
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        } else {
            isWallSliding = false;
        }
    }

    protected void Flip() {
        Vector3 localScale = transform.localScale;
        float twoCheck = Mathf.Abs(localScale.x);
        if (moveInputX < 0) {
            isFacingRight = false;
            if (twoCheck >= 2) {
                localScale.x = -2f;
            } else {
                localScale.x = -1f;
            }
            transform.localScale = localScale;
        } else if (moveInputX > 0) {
            isFacingRight = true;
            if (twoCheck >= 2) {
                localScale.x = 2f;
            } else {
                localScale.x = 1f; 
            }
            transform.localScale = localScale;
        }
    }

    protected void WallJump() {
        if (isWallSliding) {
            isWallJumping = false; 
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;
            CancelInvoke(nameof(stopWallJumping));

        } else if (wallJumpingCounter > -1) {

            wallJumpingCounter -= Time.deltaTime;
        }

        if (wallJumpingCounter > 0 && Input.GetKeyDown(KeyCode.Space)) {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * speed, jumpForce);
            wallJumpingCounter = 0;

            if (transform.localScale.x != wallJumpingDirection) {
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(stopWallJumping), wallJumpingDuration);
        }
    }

    protected void stopWallJumping() {
        isWallJumping = false;
    }


        

}





