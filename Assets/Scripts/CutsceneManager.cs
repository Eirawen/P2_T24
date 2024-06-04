using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public GameObject[] cutsceneSlides;

    public Dialogue dialogue;
    private int currentSlide = 0;
    public bool isCutscenePlaying = false;

    public static CutsceneManager Instance;

    public Image characterIcon;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public float typingSpeed = 1f;

    public Animator animator;
    public GameObject button1;
    public GameObject button2;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        lines = new Queue<DialogueLine>();
    }

    void StartCutscene(GameObject[] slides) {
        // get children
        cutsceneSlides = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) {
            cutsceneSlides[i] = transform.GetChild(i).gameObject;
        }
    }

    
    public void StartCutscene(Dialogue dialogue, GameObject[] slides)
    {
        Debug.Log("Start Cutscene!!");
        isCutscenePlaying = true;

        animator.Play("show");

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            Debug.Log("Adding dialogue line to cutscene");
            lines.Enqueue(dialogueLine);
        }
        cutsceneSlides = slides;

        DisplayNextDialogueLine();
    }

    public void DisplayNextDialogueLine()
    {
        Debug.Log("Display next dialogue line");
        if (lines.Count == 0)
        {
            Debug.Log("Ending dialogue ");
            EndDialogue();
            return;
        }
        Debug.Log("fading in next slide");
        cutsceneSlides[currentSlide].GetComponent<FadeObject>().fadeIn();
        
        // wait
        // yield new WaitForSeconds(1f);
        
        if(currentSlide > 0) {
            // while(cutsceneSlides[currentSlide].GetComponent<FadeObject>().getAlpha() < .8f) {
            //     // Debug.Log("waiting for fade out");
            // }
            Debug.Log("fading out current slide");
            cutsceneSlides[currentSlide - 1].GetComponent<FadeObject>().fadeOut();
        }
        DialogueLine currentLine = lines.Dequeue();
        currentSlide++;
        

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();
        // Debug.Log("Typing sentence");
        StartCoroutine(TypeSentence(currentLine));
        
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            // Debug.Log("Typing letter");
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        isCutscenePlaying = false;
        animator.Play("hide");
        Debug.Log("End dialogue");
        Debug.Log("Size of cutsceneSlides is " + cutsceneSlides.Length);
        cutsceneSlides[currentSlide - 1].GetComponent<FadeObject>().fadeOut();
        button1.SetActive(true);
        button2.SetActive(true);
    }
}