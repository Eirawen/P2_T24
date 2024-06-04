using UnityEngine;

public class FormManager : MonoBehaviour {
    // to do
    // figure out what buttons trigger the forms (outside of the scope of this script)
    

    public PlayerController baseController;
    public SalmonForm salmonForm;
    public SlimeForm slimeForm;
    public CatForm catForm;


    public Rigidbody2D rb;

    public PlayerController currentForm; 

    

    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        baseController = gameObject.GetComponent<PlayerController>();
        baseController.enabled = true;
        salmonForm = gameObject.GetComponent<SalmonForm>();
        salmonForm.enabled = false;
        slimeForm = gameObject.GetComponent<SlimeForm>();
        slimeForm.enabled = true;
        catForm = gameObject.GetComponent<CatForm>();
        catForm.enabled = false;
        SwitchForm(slimeForm); // switch to slime at start of the game. 
        currentForm = slimeForm;

    }


    void Update() {
        if (currentForm.isPlayerGrounded || currentForm.inWater || currentForm.isWallSliding) {

            if (Input.GetKeyDown(KeyCode.S)) {
                SwitchForm(slimeForm);
            }
            if (Input.GetKeyDown(KeyCode.F)) {
                if (currentForm.IsSalmonFormUnlocked) {
                    SwitchForm(salmonForm);
                    rb.velocity = new Vector2(0, 0);
                }
            }
            if (Input.GetKeyDown(KeyCode.C)) {
                if (currentForm.IsCatFormUnlocked) {
                    SwitchForm(catForm);
                }
            }
        }
    }

    

    public void SwitchForm(PlayerController newForm) {
        baseController.enabled = false;
        salmonForm.enabled = false;
        slimeForm.enabled = false;
        catForm.enabled = false;
        newForm.enabled = true;
        newForm.SwitchSprite();

        currentForm = newForm; 
    }
}

    
