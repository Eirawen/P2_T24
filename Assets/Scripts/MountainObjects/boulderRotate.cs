using UnityEngine;

public class boulderRotate : MonoBehaviour
{
    public Rigidbody2D rb;

    public float rotationSpeed = 200f;

    void FixedUpdate() {
       float rotationAmount = rb.velocity.x * rotationSpeed * Time.fixedDeltaTime;

        transform.Rotate(0, 0, -rotationAmount); // The negative sign dictates the direction of rotation
    }
}