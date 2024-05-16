using UnityEngine;

public class FormManager : MonoBehaviour {
    // to do
    // figure out what buttons trigger the forms (outside of the scope of this script)
    
    private PlayerController currentForm;

    public void transformtoSalmon () {
        if (currentForm != null) {
            Destroy(currentForm);
        }

        currentForm = gameObject.AddComponent<SalmonForm>();

    }


    public void transformToSlime() {
        if (currentForm != null) {
            Destroy(currentForm);
        }

        currentForm = gameObject.AddComponent<SlimeForm>();
    }
}

    
