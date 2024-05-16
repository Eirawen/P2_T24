using UnityEngine;

public class SalmonForm : PlayerController {

    private bool inWater = false;

    private int waterLayer; 

    public Sprite salmonSprite;

    public PlayerController pc; 

    // In order for these methods to work, we must have a collider object set to "is trigger" rather
    // than other types of collision. This tells Unity we're using it to trigger things rather than
    // to block movement. 

    void Start() {
        // set the ground layer to the water layer
        waterLayer = LayerMask.NameToLayer("Water");
        // set the sprite to the salmon sprite
        pc = gameObject.GetComponent<PlayerController>();
        gameObject.GetComponent<SpriteRenderer>().sprite = pc.Sprites[1];
    }
    private void OnTriggerEnter2D(Collider2D water) {
        // if we are in water, change the flag. 
        if (water.gameObject.layer == waterLayer) {
            inWater = true;
        }
    }

    protected override void Awake() {
        base.Awake();
    }

    // Unity's method called when the Collider other exits the trigger
    private void OnTriggerExit2D(Collider2D water) {
        // when leaving water change the flag
        if (water.gameObject.layer == LayerMask.NameToLayer("Water")) {
            inWater = false;
        }
    }


    protected override void MovePlayer() {
        // TODO : override salmon movement

        //need to further develop.

        // also these curly braces are messed up i was messing around in emacs ill fix it later. 

        if (inWater) {
            base.MovePlayer();
        } else {
            Flop();
        }
    }

    protected override void Jump() {
        //TODO : override salmon jump
    }


    private void Flop() {
        //TODO : what does it mean to flop
    }
}
    

