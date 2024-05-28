using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PasswordPuzzle : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button submitButton;
    public TMP_Text feedbackText;
    public GameObject objectToDeactivate; // Reference to the object you want to deactivate

    private string correctPassword = "STAR"; // Set your desired password here

    void Start()
    {
        submitButton.onClick.AddListener(CheckPassword);
    }

    void CheckPassword()
    {
        string enteredPassword = inputField.text;

        if (enteredPassword == correctPassword)
        {
            feedbackText.text = "Name Correct!"; // Optional feedback
            if (objectToDeactivate != null)
            {
                PasswordTrigger.Instance.animator.Play("hide");
                PasswordTrigger.Instance.isSolving = false;
                objectToDeactivate.SetActive(false); // Deactivate the object if the password is correct
            }
        }
        else
        {
            feedbackText.text = "Wrong Name!"; // Optional feedback
            inputField.text = "";
        }
    }
}