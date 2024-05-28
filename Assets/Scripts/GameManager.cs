using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    private static GameManager _Instance;
    public static GameManager Instance {
        get {
            if (_Instance == null) {
                _Instance = FindObjectOfType<GameManager>();
                if (_Instance == null) {
                    Debug.LogError("No GameManager found in the scene. Creating a new one.");
                    GameObject go = new GameObject("GameManager");
                    _Instance = go.AddComponent<GameManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return _Instance;
        }
    }



    void Awake() {
        if (_Instance != null && _Instance != this) {
            Destroy(this.gameObject);
        } else {
            _Instance = this;   
            DontDestroyOnLoad(this.gameObject);
        }  
    }

    
}