using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeathObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Died!");
            GameObject.FindGameObjectWithTag("Player").transform.position = PlayerController.lastCheckPointPos;
        }
    }
}
