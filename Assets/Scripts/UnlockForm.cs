using UnityEngine;


public class UnlockForm : PlayerController {
    public int formIndex = 0; 
    //salmon = 1
    //cat = 2


    // because we are deleting our player and reinsantiating it every scene, at the start of a scene, you need a collider with this script on it to re-enable the forms.
    // in fact you'll need two instances of this script for the city scene+ to give both salmon and cat forms.
    public void unlockForm(string formName) {
        switch (formName) {
            case "Salmon":
                IsSalmonFormUnlocked = true;
                Debug.Log("Salmon form unlocked");
                break;
            case "Cat":
                IsCatFormUnlocked = true;
                Debug.Log("Cat form unlocked");
                break;
            default:
                Debug.LogError("Invalid form name");
                break;
        }        
    }


    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (formIndex == 1) {
                unlockForm("Salmon");
            } else if (formIndex == 2) {
                unlockForm("Cat");
            }
        }
    }
}