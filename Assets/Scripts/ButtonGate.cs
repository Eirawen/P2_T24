using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGate : MonoBehaviour
{
    public GameObject gate;
    public GameObject Sam;
    public GameObject school;
    public float speed = 1;
    private bool isMoving;
    public bool isPressed;
    private bool isColliding;
    private float uppos;
    private float downpos;
    public bool isSamIn;
    private float pos;

    void Start() {
        isPressed = false;
        isColliding = false;
        isMoving = false;
        isSamIn = false;
        var gateCollider = gate.GetComponent<BoxCollider2D>();
        var bounds = gateCollider.bounds;
        float y = (float) bounds.size.y;
        uppos = gate.transform.position.y + y;
        downpos = gate.transform.position.y;
        // uppos = gate.transform.position + new Vector3(0, y, 0);
        // downpos = gate.transform.position; 
        pos = gate.transform.position.y;
        // pos = gate.transform.position;
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
        if (!isMoving && isColliding && Input.GetKeyDown(KeyCode.F)){
            Debug.Log("Pay respects");
            isPressed = !isPressed;
            isMoving = true;
            }
        
        if (isMoving){
            
            if (isPressed){ //move up   
                if(pos < uppos){
                    Debug.Log("up");
                    moveUp();
                    pos = gate.transform.position.y;
                }
                else{
                    if (!isSamIn)
                    {
                        isSamIn = true;
                        moveSamIn();
                    }
                    isMoving = false;
                }
            } else { //move down
                if(pos > downpos){
                    Debug.Log("down");
                    moveDown();
                    pos = gate.transform.position.y;
                }
                else{
                    isMoving = false;
                }
            }
            
        }
    }
    

    void moveUp(){
        Debug.Log("in moveUp");
        gate.transform.position += new Vector3(0, 0.1f, 0);
    }
    
    
    void moveDown(){
        Debug.Log("in moveDown");
        gate.transform.position +=  new Vector3(0, -0.1f, 0);
    }


    void moveSamIn(){
        Debug.Log("in moveSamIn");
        Sam.transform.position = new Vector3(Sam.transform.position.x + 8, Sam.transform.position.y, 0);
        school.transform.position = new Vector3(school.transform.position.x + 9, school.transform.position.y, 0);
        Sam.GetComponent<DialogueTrigger>().dialogue.dialogueLines[0].line = "Thank you for letting us in!";
        Sam.GetComponent<DialogueTrigger>().dialogue.dialogueLines[1].line = "Looks like the exit's up there, but we can't jump that high!";
        Sam.GetComponent<DialogueTrigger>().dialogue.dialogueLines[2].line = "Can you raise the water level somehow?";
    }
}