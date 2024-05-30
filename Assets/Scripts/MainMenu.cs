using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        //SceneManager.LoadScene("Game");  is a placeholder for next scene
        Debug.Log("Start Game");
        MusicManager.Instance.PlayMusic("Game");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}