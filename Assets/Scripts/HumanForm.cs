using UnityEngine;

public class HumanForm : PlayerController {

    public bool onWall = false;
    public Sprite humanSprite;

    public SpriteRenderer spriteRenderer;
    public PlayerController pc;

    
    public LayerMask iceClimbLayer;

    private BoxCollider2D boxCollider; 

    protected override void Awake() {
        base.Awake();
        pc = gameObject.GetComponent<PlayerController>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        // humanSprite = pc.Sprites[4];

        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        iceClimbLayer = LayerMask.GetMask("Platform");
    }



}