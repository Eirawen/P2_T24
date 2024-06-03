using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SideBar : MonoBehaviour
{
    public Image slimeHotkey;
    public Sprite slimeOff;
    public Sprite slimeOn;

    public Image fishHotkey;
    public Sprite fishOff;
    public Sprite fishOn;
    // add slimeHotkey
    public Image catHotkey;
    public Sprite catOff;
    public Sprite catOn;

    public Image birdHotkey;
    public Sprite birdOff;
    public Sprite birdOn;
    //public PlayerController currentForm; 
    void Start ()
	{
		// Create a temporary reference to the current scene.
		Scene currentScene = SceneManager.GetActiveScene();

		// Retrieve the name of this scene.
		string sceneName = currentScene.name;
        slimeHotkey.sprite = slimeOn;
        fishHotkey.sprite = fishOn;
        catHotkey.sprite = catOn;
        birdHotkey.sprite = birdOn;

        slimeHotkey.enabled = true;
        fishHotkey.enabled = true;
        catHotkey.enabled = false;
        birdHotkey.enabled = false;
		if (sceneName == "WaterScene") 
		{
            // should be slime
            slimeHotkey.sprite = slimeOff;
		}
		else if (sceneName == "CityScene")
		{
            fishHotkey.sprite = fishOff;
			catHotkey.enabled = true;
           
		}else if (sceneName == "MountainScene")
		{   
            catHotkey.sprite = catOn;
			catHotkey.enabled = true;
            birdHotkey.enabled = true;
		}

    } 
    void Update() {
            if (Input.GetKeyDown(KeyCode.S)) {
                // change hotkey appearance
                // slime form
                if (slimeHotkey.sprite == slimeOff) {
                    slimeHotkey.sprite = slimeOff;
                } else {
                    slimeHotkey.sprite = slimeOff;
                    fishHotkey.sprite = fishOn;
                    catHotkey.sprite = catOn;
                    birdHotkey.sprite = birdOn;
                }
                
            }
            if (Input.GetKeyDown(KeyCode.F)) {
               if (fishHotkey.sprite == fishOff) {
                    fishHotkey.sprite = fishOff;
                } else {
                    fishHotkey.sprite = fishOff;
                    slimeHotkey.sprite = slimeOn;
                   
                    catHotkey.sprite = catOn;
                    birdHotkey.sprite = birdOn;
                }
                
            }
            if (Input.GetKeyDown(KeyCode.C)) {
                if (catHotkey.sprite == catOff) {
                    catHotkey.sprite = catOff;
                } else {
                    catHotkey.sprite = catOff;
                    slimeHotkey.sprite = slimeOn;
                    fishHotkey.sprite = fishOn;
                   
                    birdHotkey.sprite = birdOn;
                }
            }
        
    }
}