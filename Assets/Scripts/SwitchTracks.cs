using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTracks : MonoBehaviour
{
    public string Track;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MusicManager.Instance.PlayMusic(Track);
        }
    }
}
