using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System; 


// put this on a game object. Specify the scene to load in the inspector. We can also make it a button push. 
public class SceneLoader : MonoBehaviour {
    public int sceneToLoad = -1;
    private GameObject[] killPlayer;

    public void LoadScene() {
        if (sceneToLoad >= 0) {
                SceneManager.LoadScene(sceneToLoad);

        } else {
            Debug.LogWarning("Scene to load is not set.");
        }
    }

    public void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            LoadScene();
        }
    }
}
      
