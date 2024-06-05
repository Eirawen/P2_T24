using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWater: MonoBehaviour{
    public ButtonGate buttonGate;
    public GameObject Sam;
    public GameObject school;
    public GameObject water;
    public GameObject water2;
    public GameObject exit;
    private bool isPressed;   
    private bool isColliding; 
    private bool isMoving;
    private float uppos;
    private float downpos;
    private float pos;
    private bool isADACompliant;

    void Start(){
        isPressed = false;
        isColliding = false;
        uppos = 1.48f;
        downpos = -1.33f;
        pos = water.transform.position.y;
    }

     void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            isColliding = true;
        }
    }


    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            isColliding = false;        
        }
    }

    void Update(){

        if(isPressed && buttonGate.isPressed){
            if(pos > downpos){
                moveDown();
                pos = water.transform.position.y;
            }
            else{
                isMoving = false;
                isPressed = false;
            }
        }

        if (!isMoving && isColliding && Input.GetKeyDown(KeyCode.E) && !buttonGate.isPressed){
            Debug.Log("Pay respects");
            isPressed = !isPressed;
            isMoving = true;
            }
        
        if (isMoving){
            
            if (isPressed){ //move up   
                if(pos < uppos){
                    Debug.Log("up");
                    moveUp();
                    pos = water.transform.position.y;
                }
                else{
                    if (!isADACompliant && buttonGate.isSamIn){
                        moveSamOut();
                        isADACompliant = true;
                    }
                    isMoving = false;
                }
            } else { //move down
                if(pos > downpos){
                    Debug.Log("down");
                    moveDown();
                    pos = water.transform.position.y;
                }
                else{
                    isMoving = false;
                }
            }
            
        }
    }
    
    void moveUp(){
        Debug.Log("in moveUp");
        water.transform.position += new Vector3(0, 0.05f, 0);
        water2.transform.position += new Vector3(0, 0.05f, 0);
    }
    
    
    void moveDown(){
        Debug.Log("in moveDown");
        water.transform.position +=  new Vector3(0, -0.05f, 0);
        water2.transform.position +=  new Vector3(0, -0.05f, 0);
    }


    void moveSamOut(){
        Debug.Log("in moveSamOut");
        Sam.GetComponent<DialogueTrigger>().dialogue.dialogueLines[0].line = "You did it!";
        Sam.GetComponent<DialogueTrigger>().dialogue.dialogueLines[1].line = "Now we can all swim into the city!";
        Sam.GetComponent<DialogueTrigger>().dialogue.dialogueLines[2].line = "Head to that opening and we'll follow you out!";
        Sam.GetComponent<DialogueTrigger>().TriggerDialogue();
        exit.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}