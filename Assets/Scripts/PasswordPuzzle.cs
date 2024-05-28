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
        }
        else
        {
            feedbackText.text = "Wrong Name!"; // Optional feedback
        }
    }
}