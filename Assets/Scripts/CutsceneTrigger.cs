using UnityEngine;
using System.Collections;

public class CutsceneTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    // array of the cutscene slides
    private GameObject[] cutsceneSlides;
    private bool isPlayerInTrigger = false;

    private bool hasPlayed = false;

    void Start() {
        // get children
        cutsceneSlides = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) {
            Debug.Log("Getting cutscene slide " + i);
            cutsceneSlides[i] = transform.GetChild(i).gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player in trigger");
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isPlayerInTrigger = false;
        }
    }

    public void TriggerCutscene()
    {
        hasPlayed = true;
        CutsceneManager.Instance.StartCutscene(dialogue, cutsceneSlides);
    }

    void Update() {
        if(isPlayerInTrigger && !hasPlayed && !CutsceneManager.Instance.isCutscenePlaying) {
            // trigger cutscene fade in and dialogue
            Debug.Log("Triggering cutscene");
            TriggerCutscene();
        }

    }
}