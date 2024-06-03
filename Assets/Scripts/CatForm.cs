using UnityEngine;

public class CatForm : PlayerController {
    public bool onWall = false;
    public Sprite catSprite;

    public SpriteRenderer spriteRenderer;
    public PlayerController pc;

    public float catGravityScale = 0.9f;
    public float catJumpScale = 1.5f;
    public LayerMask catJumpLayer;

    private BoxCollider2D boxCollider; 


    public float forceSmooth = 100.0f;
    public float upwardScale = 3.0f; 


    protected override void Awake() {
        base.Awake();
        pc = gameObject.GetComponent<PlayerController>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        catSprite = pc.Sprites[3];

        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        catJumpLayer = LayerMask.GetMask("Platform");


    }

     protected override void Update() { // called every frame
        moveInputX = Input.GetAxisRaw("Horizontal");
        moveInputY = Input.GetAxisRaw("Vertical");

        if (!isWallJumping) {
            base.MovePlayer();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (canJump()) {
                Jump();
            }
        }

        base.Update();

    }

 


    public void catJump() {
        Vector2 jumpUp = Vector2.up * upwardScale;
        Vector2 jumpDirection = jumpUp + lastContactNormal;
        jumpDirection.Normalize();
        rb.AddForce(jumpDirection * jumpForce * catJumpScale * forceSmooth, ForceMode2D.Force);
    }
    protected override void Jump() {

        if (canJump()) {

            rb.AddForce(Vector2.up * jumpForce * catJumpScale, ForceMode2D.Impulse);
        }
    }



    private bool catWallCheck (Collision2D collision) {
        return ((1 << collision.gameObject.layer) & catJumpLayer) != 0;
    }

    private bool canJump() {
        return isPlayerGrounded && !isWallSliding; 
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (catWallCheck(collision)) {
            onWall = true;
            if (collision.contacts.Length > 0) {
                lastContactNormal = collision.contacts[0].normal;
                Debug.Log("Wall normal: " + lastContactNormal);
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (catWallCheck(collision)) {
            onWall = false;
        }
    }

    void OnEnable() {
        Debug.Log("Cat form enabled");
        rb.gravityScale = catGravityScale;
        
    }

    void OnDisable() {
        rb.gravityScale = normalGravityScale;
    }

    public override void SwitchSprite() {
        spriteRenderer.sprite = catSprite;

    }

   
}
