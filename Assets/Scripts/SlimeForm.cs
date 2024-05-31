using UnityEngine;

public class SlimeForm : PlayerController {
    private bool onWall = false;
    public Sprite slimeSprite;
    public Sprite compressedSprite;

    public SpriteRenderer spriteRenderer;

    public PlayerController pc;

    public float slimeGravityScale = 0.0f;
    private BoxCollider2D boxCollider; // stores the player's box collider
    private Vector2 originalSlimeSize; // stores the player's original size

    public float compressHeightScale = 0.5f; // how much the player compresses their height
    public float compressWidthScale = 1.5f; // how much the player elongates their width
    public LayerMask decompressCollisions; // defines the layer for objects which stop decompression 


    void Start() {
        // slimeSprite = pc.Sprites[0];
    }

    protected override void Awake() {
        base.Awake();
        pc = gameObject.GetComponent<PlayerController>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        slimeSprite = pc.Sprites[0];
        compressedSprite = pc.Sprites[2]; 

        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        originalSlimeSize = boxCollider.size;
        decompressCollisions = LayerMask.GetMask("Ground", "Platform");

    }

    protected override void Update() {
        moveInputX = Input.GetAxis("Horizontal");
        moveInputY = Input.GetAxis("Vertical");

        MovePlayer();

        if (Input.GetKeyDown(KeyCode.K)) {
            Compress();
        } else if (Input.GetKeyDown(KeyCode.L)) {
            deCompress();
        }

        base.Update();
    }


    

    private bool isSticky(Collision2D collision) {
        return collision.gameObject.tag == "sticky";
        }

    void OnCollisionEnter2D(Collision2D collision) {
        if (isSticky(collision)) {
            onWall = true;
            stickToWall();
        }
    }

    void OnCollisionExit2D(Collision2D collision) {
        if (isSticky(collision)) {
            onWall = false;
            unstickFromWall();
        }
    }

    private void stickToWall() {
        if (onWall && enabled) {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.gravityScale = slimeGravityScale;
            
        }
    }

    private void unstickFromWall() {
        if (!onWall && enabled) {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.gravityScale = normalGravityScale;
        }
    }

    private void Compress() {
        boxCollider.size = new Vector2(originalSlimeSize.x * compressWidthScale, originalSlimeSize.y * compressHeightScale);
        spriteRenderer.sprite = compressedSprite;
    }

    private void deCompress() {
        bool compressable = canDeCompress();
        if (compressable) {
        boxCollider.size = originalSlimeSize;
        SwitchSprite();
        }

    }

    private bool canDeCompress() {
        // position of the top center of the current slime's collider
        Vector2 topCenter = new Vector2(transform.position.x, transform.position.y + boxCollider.size.y / 2);

        //size of the box to check. Should be as wide as the slime and tall enough to cover decompression.
        Vector2 checkSize = new Vector2(boxCollider.size.x, originalSlimeSize.y / 2);

        // Adjust the position to be just above the current top of the slime, moving up by half the height of the checkSize
        Vector2 position = topCenter + new Vector2(0, checkSize.y / 2);

        Collider2D[] hits = Physics2D.OverlapBoxAll(position, checkSize, 0, decompressCollisions);
        return hits.Length == 0; // Can decompress if no obstacles are found

    }


    




    

    
    public override void SwitchSprite() {
        spriteRenderer.sprite = slimeSprite;
    }

    void OnEnable() {
        Debug.Log("Slime form enabled");
        
    }

    protected override void MovePlayer() {
        float x = moveInputX * speed;
        float y = rb.velocity.y;
    
        if (onWall) {
            y = moveInputY * speed;
            Vector2 targetVelocity = new Vector2(x, y);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocitySmooth, movementSmooth);
        }
        else {
            base.MovePlayer();
        }
    }
}

// TODO:
//Modify physics objects for "sticky" things to stop the slime from sliding down.

// old collision logic, didn't want to delete.

// void OnCollisionEnter2D(Collision2D  collision) {
//             Collider2D collider = collision.collider;
//             if(collider.tag == "sticky"){
//                 Debug.Log("sticky");
//                 //initial logic, TODO: fix collision so it recognized top/bottom and left/right, later add sticky logic 
//                 Vector3 contactPoint = collision.contacts[0].point;
//                 Vector3 min = collider.bounds.min;
//                 Vector3 max = collider.bounds.max;

//                 bool right = contactPoint.x > min.x;
//                 bool top = contactPoint.y > min.y;
//                 Debug.Log("minX: " + min.x);
//                 Debug.Log("minY: " + min.y);
//                 Debug.Log("collisionPoint: " + contactPoint.x + ", " + contactPoint.y);
//                 Debug.Log("right: " + right);
//                 Debug.Log("top: " + top);

//             }
            
//     }
