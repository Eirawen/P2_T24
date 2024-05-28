using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonWater: MonoBehaviour{
    public ButtonGate buttonGate;
    public GameObject water;
    private bool isPressed;   
    private bool isColliding; 
    private bool isMoving;
    private float uppos;
    private float downpos;
    private float pos;

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
        if (!isMoving && isColliding && Input.GetKeyDown(KeyCode.F) && !buttonGate.isPressed){
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
    }
    
    
    void moveDown(){
        Debug.Log("in moveDown");
        water.transform.position +=  new Vector3(0, -0.05f, 0);
    }

}