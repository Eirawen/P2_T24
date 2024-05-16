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
        pc = gameObject.GetComponent<PlayerController>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        slimeSprite = pc.Sprites[0];
    }
    protected override void MovePlayer() {


        base.MovePlayer();
    }

    public override void SwitchSprite() {
        spriteRenderer.sprite = slimeSprite;
    }

    void OnEnable() {
        Debug.Log("Slime form enabled");
        
    }
}
