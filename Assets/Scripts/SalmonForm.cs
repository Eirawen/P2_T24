using UnityEngine;

public class SalmonForm : PlayerController {

    private int waterLayer; 

    public float salmonJumpScale = 0.4f;



    public Sprite salmonSprite;

    public PlayerController pc; 

    public SpriteRenderer spriteRenderer;


    public float salmonGravityScale = 0.3f; 

    public float flopForce;

    public float flopJumpScale = 0.1f; 

    public float salmonAirControl = 0.9f;
    public float salmonAirGravityScale = 0.6f;

    public float waterJumpTime = 2.0f; 
    public float waterJumpCounter; 



 

    // In order for collision checking to work, we must have a collider object set to "is trigger" on water objects rather
    // than other types of collision. This tells Unity we're using it to trigger things rather than
    // to block movement. 

    void Start() {
        // set the ground layer to the water layer
        waterLayer = LayerMask.NameToLayer("Water");
        // set the sprite to the salmon sprite
        
    }

    protected override void Awake() {
            base.Awake();
            pc = gameObject.GetComponent<PlayerController>();
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            salmonSprite = pc.Sprites[1];
            flopForce = 0.6f;
            waterJumpCounter = 0.0f;
        }


    private void OnTriggerStay2D(Collider2D water) {
        // if we are in water, change the flag. 
        
        if (water.gameObject.layer == waterLayer && enabled) {
            inWater = true;
        }
        if (enabled) { 
            rb.gravityScale = salmonGravityScale;
        }
    }



    private void OnTriggerEnter2D(Collider2D water) {
        // if we are in water, change the flag. 
        
        if (water.gameObject.layer == waterLayer) {
            if (enabled) {
                inWater = true;
                Debug.Log("In water");
            }
        }
        if (enabled) { 
            rb.gravityScale = salmonGravityScale;
        }
    }

    

    // Unity's method called when the Collider other exits the trigger
    private void OnTriggerExit2D(Collider2D water) {

        // when leaving water change the flag
        if (water.gameObject.layer == waterLayer) {
            inWater = false;
            
        }
        if (enabled) {
            rb.gravityScale = salmonAirGravityScale;
        }
    }


    protected override void MovePlayer() {
        float x = moveInputX * speed;
        float y = rb.velocity.y;
    
        if (inWater) {
            y = moveInputY * speed;
            Vector2 targetVelocity = new Vector2(x, y);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocitySmooth, movementSmooth);
        } else {
            float velocity = rb.velocity.x;
            if (isPlayerGrounded) {
                velocity = 0;
            }
            switch (velocity) {
                case float n when n > 0.1f:
                    x = speed * salmonAirControl;
                    break;
                case float n when n < -0.1f:
                    x = -speed * salmonAirControl;
                    break;
                default:
                    x = 0;
                    break;
            }
            Vector2 targetVelocity = new Vector2(x, y);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocitySmooth, movementSmooth);
            
        }
    }

    protected override void Update() {
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");
        
        if (inWater) {
            MovePlayer();
        } else {
            // Flop();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (inWater && waterJumpCounter <= 0) {
                Jump();
                waterJumpCounter = waterJumpTime;
            } 
        }
        if (waterJumpCounter >= 0) {
            waterJumpCounter -= Time.deltaTime;
        }

        base.Update();
    }


    protected override void Jump() {
        rb.AddForce(Vector2.up * jumpForce * salmonJumpScale, ForceMode2D.Impulse);
    }


    private void Flop() {
        isPlayerMoving = base.isMoving();
        if (!isPlayerMoving) {
            rb.AddForce(Vector2.up * salmonJumpScale * flopForce * flopJumpScale, ForceMode2D.Impulse);      
        }
    }

    public override void SwitchSprite() {
        spriteRenderer.sprite = salmonSprite;

    }

    void OnEnable() {
        Debug.Log("Salmon form enabled");
        rb.gravityScale = salmonGravityScale;
    }

    void OnDisable() {
        rb.gravityScale = normalGravityScale;
    }
}
    

