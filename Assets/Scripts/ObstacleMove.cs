using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float speed = 1.0f;
    public float destroyTime = 5.0f;
    public float x =  0f;
    public float y = 0f;

    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void Update()
    {
        float randomSpeed = Random.Range(-2.0f, 2.0f); //if time, make this a variable
        Vector3 update = new Vector3 (x, y, 0);
        transform.position += update * (speed + randomSpeed) * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}