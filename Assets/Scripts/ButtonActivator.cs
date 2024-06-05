using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonActivator : MonoBehaviour
{
    public Button myButton; // Reference to the button

    void Update()
    {
        // Check if the space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // If the button is assigned, invoke its onClick event
            if (myButton != null)
            {
                myButton.onClick.Invoke();
            }
        }
    }
}