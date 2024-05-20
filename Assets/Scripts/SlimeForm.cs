using UnityEngine;

public class SlimeForm : PlayerController {
    private bool onWall = false;
    public Sprite slimeSprite;

    public SpriteRenderer spriteRenderer;

    public PlayerController pc;

    void Start() {
        // slimeSprite = pc.Sprites[0];
    }


    void OnCollisionEnter2D(Collision2D  collision) {
            Collider2D collider = collision.collider;
            if(collider.tag == "sticky"){
                Debug.Log("sticky");
                //initial logic, TODO: fix collision so it recognized top/bottom and left/right, later add sticky logic 
                Vector3 contactPoint = collision.contacts[0].point;
                Vector3 min = collider.bounds.min;
                Vector3 max = collider.bounds.max;

                bool right = contactPoint.x > min.x;
                bool top = contactPoint.y > min.y;
                Debug.Log("minX: " + min.x);
                Debug.Log("minY: " + min.y);
                Debug.Log("collisionPoint: " + contactPoint.x + ", " + contactPoint.y);
                Debug.Log("right: " + right);
                Debug.Log("top: " + top);

            }
            
    }


    protected override void Awake() {
        base.Awake();
        rb = gameObject.GetComponent<Rigidbody2D>();
        pc = gameObject.GetComponent<PlayerController>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        slimeSprite = pc.Sprites[0];


        
    }
    protected override void MovePlayer() {

        base.MovePlayer();
    }
    protected override void Update() {
        moveInputX = Input.GetAxis("Horizontal");
        MovePlayer();
    }
    public override void SwitchSprite() {
        spriteRenderer.sprite = slimeSprite;
    }

    void OnEnable() {
        Debug.Log("Slime form enabled");
        
    }
}
