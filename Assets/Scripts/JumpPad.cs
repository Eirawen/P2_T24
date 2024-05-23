using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float bounce = 20f;
    public float threshold = 0.1f; // Threshold for considering collision on top

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ContactPoint2D contact = collision.GetContact(0); // Get the first contact point
            Vector2 jumpPadPos = transform.position;
            Vector2 collisionPos = contact.point;

            if (collisionPos.y > jumpPadPos.y + threshold) // Check if collision is on top
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            }
        }
    }
}
