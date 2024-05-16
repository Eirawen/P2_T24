using UnityEngine;

public class SlimeForm : PlayerController {
    private bool onWall = false;
    public Sprite slimeSprite;

    public PlayerController pc;

    void Start() {
        pc = gameObject.GetComponent<PlayerController>();
        gameObject.GetComponent<SpriteRenderer>().sprite = pc.Sprites[0];
    }

    protected override void Awake() {
        base.Awake();
    }
    protected override void MovePlayer() {
        // TODO : override salmon movement

        //need to further develop.

        // also these curly braces are messed up i was messing around in emacs ill fix it later. 

        base.MovePlayer();
    }

    public override void SwitchSprite() {
        gameObject.GetComponent<SpriteRenderer>().sprite = pc.Sprites[0];
    }
}
