using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordTrigger : MonoBehaviour
{
    public Animator animator;
    private bool isPlayerInTrigger = false;

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed E");
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
            animator.Play("hide");
        }
    }
}
