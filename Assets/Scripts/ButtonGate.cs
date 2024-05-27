using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGate : MonoBehaviour
{
    public GameObject gate;
    public float speed = 1;
    private bool isMoving;
    private bool isPressed;
    private bool isColliding;
    private Vector3 uppos;
    private Vector3 downpos;
    private Vector3 pos;


    void Start() {
        isPressed = false;
        isColliding = false;
        isMoving = false;
        var gateCollider = gate.GetComponent<BoxCollider2D>();
        var bounds = gateCollider.bounds;
        float y = (float) bounds.size.y;
        uppos = gate.transform.position + new Vector3(0, y, 0);
        downpos = gate.transform.position; 
        pos = gate.transform.position;
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
                if(pos.y < uppos.y){
                    Debug.Log("up");
                    moveUp();
                    pos = gate.transform.position;
                }
                else{
                    isMoving = false;
                }
            } else { //move down
                if(pos.y > downpos.y){
                    Debug.Log("down");
                    moveDown();
                    pos = gate.transform.position;
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

}