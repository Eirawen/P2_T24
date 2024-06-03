using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueCharacter
{
    public string name;
    public Sprite icon;
}

[System.Serializable]
public class DialogueLine
{
    public DialogueCharacter character;
    [TextArea(3, 10)]
    public string line;
}

[System.Serializable]
public class Dialogue
{
    public List<DialogueLine> dialogueLines = new List<DialogueLine>();
}

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public GameObject attentionIcon;
    private bool isPlayerInTrigger = false;
    public bool isAutomatic = false;
    private bool hasPlayed = false;

    public void TriggerDialogue()
    {
        hasPlayed = true;
        DialogueManager.Instance.StartDialogue(dialogue);
    }

    private void Update()
    {
        if (!isPlayerInTrigger && !hasPlayed && !isAutomatic && attentionIcon != null){
            attentionIcon.GetComponent<SpriteRenderer>().enabled = true;

        }

        if (isPlayerInTrigger && isAutomatic && !DialogueManager.Instance.isDialogueActive && !hasPlayed){
            TriggerDialogue();
        }

        // colliding but haven't pressed E yet
        // else if (isPlayerInTrigger && !Input.GetKeyDown(KeyCode.E) && !isAutomatic){
        //     if (attentionIcon != null){
        //         attentionIcon.GetComponent<SpriteRenderer>().enabled = true;
        //     }
        //         // attentionIcon.SetActive(true);
        //     // GetComponent<LineRenderer>().enabled = true;
        // }
        
        else if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Pressed E");
            Debug.Log(transform.position);
            SoundManager.Instance.PlaySound3D("Interact", transform.position);
            TriggerDialogue();
            attentionIcon.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
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
}