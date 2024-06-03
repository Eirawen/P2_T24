using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCityMusic : MonoBehaviour
{
    public bool hasStarted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" & !hasStarted)
        {
            MusicManager.Instance.PlayMusic("City");
            hasStarted = true;
        }
    }
}
