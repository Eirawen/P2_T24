public class FormManager : MonoBehaviour {
    // to do
    // figure out what buttons trigger the forms (outside of the scope of this script)
    
    private PlayerController currentForm;

    public void TransformtoSalmon {
        if (currentForm) {
            Destroy(currentForm);
        }

        currentForm = gameObject.AddComponent<SalmonForm>();

    }


    public void TransformToSlime {
        if (currentForm) {
            Destroy(currentForm);
        }

        currentForm = gameObject.AddComponent<SlimeMovement>();
    }

    
