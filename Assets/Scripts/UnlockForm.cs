using UnityEngine;


public class UnlockForm : MonoBehaviour {
    public int formIndex = 0; 
    public PlayerController pc; 
    public SlimeForm sp;
    public SalmonForm sap;
    public CatForm cap;
    public Collider2D formy; 
    //salmon = 1
    //cat = 2


    // because we are deleting our player and reinsantiating it every scene, at the start of a scene, you need a collider with this script on it to re-enable the forms.
    // in fact you'll need two instances of this script for the city scene+ to give both salmon and cat forms.


    //also this is so dumb but yes you do have to drag them all in. 
    


    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            if (formIndex == 1) {
                pc.unlockForm("Salmon");
                sp.unlockForm("Salmon");
                sap.unlockForm("Salmon");
                cap.unlockForm("Salmon");
            } else if (formIndex == 2) {
                pc.unlockForm("Cat");
                sp.unlockForm("Cat");
                sap.unlockForm("Cat");
                cap.unlockForm("Cat");
            }
        }
    }
}