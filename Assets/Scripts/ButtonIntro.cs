using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonIntro : MonoBehaviour
{
    public GameObject sign;
    private bool isColliding;

    void Start() {
        isColliding = false;
        sign.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Colliding");
            isColliding = true;
        }
    }


    void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            Debug.Log("exit colliding");
            isColliding = false;        
        }
    }

    void Update(){
        if (isColliding && Input.GetKeyDown(KeyCode.E)){
            Debug.Log("active");
            gameObject.SetActive(false);
            sign.SetActive(true);
        }
    }

}