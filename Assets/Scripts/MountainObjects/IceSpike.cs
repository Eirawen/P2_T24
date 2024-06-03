
using UnityEngine;

public class IceSpike : MonoBehaviour {
    public Rigidbody2D rb;

    void Update() {
        if (transform.position.y < -10) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}