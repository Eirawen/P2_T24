using UnityEngine;

public class FormManager : MonoBehaviour {
    // to do
    // figure out what buttons trigger the forms (outside of the scope of this script)
    

    public PlayerController baseController;
    public SalmonForm salmonForm;
    public SlimeForm slimeForm;
    public CatForm catForm;

    public PlayerController currentForm;

    

    void Start() {
        baseController = gameObject.GetComponent<PlayerController>();
        baseController.enabled = true;
        salmonForm = gameObject.GetComponent<SalmonForm>();
        salmonForm.enabled = false;
        slimeForm = gameObject.GetComponent<SlimeForm>();
        slimeForm.enabled = true;
        catForm = gameObject.GetComponent<CatForm>();
        catForm.enabled = false;
        SwitchForm(slimeForm); // switch to slime at start of the game. 

    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.X)) {
            SwitchForm(slimeForm);
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            SwitchForm(salmonForm);
        }
        if (Input.GetKeyDown(KeyCode.V)) {
            SwitchForm(catForm);
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

    
