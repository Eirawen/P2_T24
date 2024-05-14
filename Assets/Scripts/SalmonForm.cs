using UnityEngine;

public class SalmonForm : PlayerController {

    private bool inWater = false;

    // In order for these methods to work, we must have a collider object set to "is trigger" rather
    // than other types of collision. This tells Unity we're using it to trigger things rather than
    // to block movement. 
    private void OnTriggerEnter2D(Collider2D water) {
        // if we are in water, change the flag. 
        if (water.gameObject.layer == LayerMask.NameToLayer("Water")) {
            inWater = true;
            }
        }

    // Unity's method called when the Collider other exits the trigger
    private void OnTriggerExit2D(Collider2D water) {
        // when leaving water change the flag
        if (water.gameObject.layer == LayerMask.NameToLayer("Water")) {
            isInWater = false;
            }
        }


    public override void Move() {
        //override salmon movement

        //need to further develop.

        if (inWater) {
            base.Move();
            } else     {
            Flop();
            }
        }

    public override void Jump() {
        //override salmon jump
        }


    private void Flop() {

        }
    }
    

