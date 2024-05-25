using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float speed = 1.0f;
    public float destroyTime = 5.0f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        float randomSpeed = Random.Range(-2.0f, 2.0f); //if time, make this a variable
        transform.position += Vector3.left * (speed + randomSpeed) * Time.deltaTime;
        // transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}