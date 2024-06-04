using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider musicSlider;
    public Slider sfxSlider;

    public GameObject optionsMenu; // options menu for settings
    public GameObject audioMenu; // audio menu for settings
    public GameObject controlsMenu; // controls menu for settings

    public void Start()
    {
        LoadVolume();
        optionsMenu.SetActive(false); // Ensure options menu is initially inactive
    }

    public void Play()
    {
        SceneManager.LoadScene("IntroScene");
        Debug.Log("Start Game");
        MusicManager.Instance.PlayMusic("Intro");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void UpdateSoundVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }

    public void SaveVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }

    public void OpenVolume()
    {
        audioMenu.SetActive(!optionsMenu.activeSelf);
    }

    public void OpenControls()
    {
        controlsMenu.SetActive(!optionsMenu.activeSelf);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!optionsMenu.activeSelf)
            {
                SaveVolume();
            }
            optionsMenu.SetActive(!optionsMenu.activeSelf); // Toggle options menu
        }
    }
}