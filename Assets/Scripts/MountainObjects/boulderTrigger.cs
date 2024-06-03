using UnityEngine;

public class boulderTrigger : MonoBehaviour {
    public Rigidbody2D rb;


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}