using UnityEngine;


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
                }
            }
            return _Instance;
        }
    }



    void Awake() {
        if (_Instance != null && _Instance != this) {
            Destroy(gameObject);
        } else {
            _Instance = this;   
            DontDestroyOnLoad(gameObject);
        }  
    }
}