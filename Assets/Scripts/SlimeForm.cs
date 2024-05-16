using UnityEngine;

public class SlimeForm : PlayerController {
    private bool onWall = false;
    public Sprite slimeSprite;

    public SpriteRenderer spriteRenderer;

    public PlayerController pc;

    void Start() {
        
    }

    protected override void Awake() {
        base.Awake();
        rb = gameObject.GetComponent<Rigidbody2D>();
        pc = gameObject.GetComponent<PlayerController>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        slimeSprite = pc.Sprites[0];
        // currentSprite = slimeSprite;


        
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
        currentSprite = slimeSprite;
    }

    void OnEnable() {
        Debug.Log("Slime form enabled");
        
    }
}
