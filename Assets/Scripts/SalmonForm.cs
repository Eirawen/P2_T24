using UnityEngine;

public class SalmonForm : PlayerController {

    private bool inWater = false;
    private int waterLayer; 

    public float salmonJumpScale = 0.4f;



    public Sprite salmonSprite;

    public PlayerController pc; 

    public SpriteRenderer spriteRenderer;


    public float salmonGravityScale = 0.3f; 
    public float normalGravityScale = 1.0f;

    public float flopForce = 1.0f; 

    public float flopJumpScale = 0.1f; 


 

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
        }



    private void OnTriggerEnter2D(Collider2D water) {
        // if we are in water, change the flag. 
        if (water.gameObject.layer == waterLayer) {
            inWater = true;
        }
    }

    

    // Unity's method called when the Collider other exits the trigger
    private void OnTriggerExit2D(Collider2D water) {
        // when leaving water change the flag
        if (water.gameObject.layer == LayerMask.NameToLayer("Water")) {
            inWater = false;
        }
    }


    protected override void MovePlayer() {
        if (inWater) {
            base.MovePlayer();
        } else {
            Flop();
        }
    }

    protected override void Update() {
        moveInput = Input.GetAxis("Horizontal");
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (inWater) {
                Jump();
            }
        }
    }


    protected override void Jump() {
        rb.AddForce(Vector2.up * jumpForce * salmonJumpScale, ForceMode2D.Impulse);
    }


    private void Flop() {
        isPlayerMoving = base.isMoving();
        if (!isPlayerMoving) {
            rb.AddForce(Vector2.left * flopForce, ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * salmonJumpScale * flopForce * flopJumpScale, ForceMode2D.Impulse);      
        }

        if (!isPlayerMoving) {
            rb.AddForce(Vector2.right * flopForce, ForceMode2D.Impulse);
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
    

