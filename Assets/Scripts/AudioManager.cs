using UnityEngine;

public class AudioManager : MonoBehaviour {
    //Singleton pattern for the audiomanager. You can access the audiomanager from any script by calling AudioManager.Instance
    private static AudioManager _Instance;
    public static AudioManager Instance {
        get {
            if (_Instance == null) {
                _Instance = FindObjectOfType<AudioManager>();
                if (_Instance == null) {
                    Debug.LogError("No AudioManager found in the scene. Creating a new one.");
                    GameObject go = new GameObject("AudioManager");
                    _Instance = go.AddComponent<AudioManager>();
                }
            }
            return _Instance;
        }
    }

    private void Awake() {
        if (_Instance == null) {
            _Instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (_Instance != this) {
            Destroy(gameObject);
        }

    }
}