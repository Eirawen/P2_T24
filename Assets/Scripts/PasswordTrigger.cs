using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordTrigger : MonoBehaviour
{
    public static PasswordTrigger Instance;

    public Animator animator;
    private bool isPlayerInTrigger = false;
    public bool isSolving = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed E");
            isSolving = true;
            animator.Play("show");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInTrigger = false;
            isSolving = false;
            animator.Play("hide");
        }
    }
}
