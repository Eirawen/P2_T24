using UnityEngine;
using UnityEngine.SceneManagement;

// put this on a game object. Specify the scene to load in the inspector. We can also make it a button push. 
public class SceneLoader : MonoBehaviour {
    public string sceneToLoad;

    public void LoadScene() {
        if (!string.IsNullOrEmpty(sceneToLoad)) {
                SceneManager.LoadScene(sceneToLoad);
        } else {
            Debug.LogWarning("Scene to load is not set.");
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            LoadScene();
        }
    }
}
      
