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

    public bool IsSalmonFormUnlocked { get; private set; } = false;
    public bool IsSlimeFormUnlocked { get; private set; } = true;  // slime form is unlocked by default
    public bool IsCatFormUnlocked { get; private set; } = false;
    public bool IsHumanFormUnlocked { get; private set; } = false;



    void Awake() {
        if (_Instance != null && _Instance != this) {
            Destroy(this.gameObject);
        } else {
            _Instance = this;   
            DontDestroyOnLoad(this.gameObject);
        }  
    }

    public void unlockForm(string formName) {
        switch (formName) {
            case "Salmon":
                IsSalmonFormUnlocked = true;
                Debug.Log("Salmon form unlocked");
                break;
            case "Slime":
                IsSlimeFormUnlocked = true;
                Debug.Log("Slime form unlocked");
                break;
            case "Cat":
                IsCatFormUnlocked = true;
                Debug.Log("Cat form unlocked");
                break;
            case "Human":
                IsHumanFormUnlocked = true;
                Debug.Log("Human form unlocked");
                break;
            default:
                Debug.LogError("Invalid form name");
                break;
        }        
    }
}