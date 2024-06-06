using UnityEngine;


public class Parallax : MonoBehaviour {
    private float length, height, startposx, startposy; 
    public GameObject cam; 
    public float parallaxScale; 
    public float VerticalOffset;

    void Start() {
        startposx = transform.position.x; 
        startposy = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.x; 
        height = GetComponent<SpriteRenderer>().bounds.size.y;
        VerticalOffset = 0.0f;
    }

    void Update() {
        float tempX = (cam.transform.position.x * (1 - parallaxScale)); 
        float distX = (cam.transform.position.x * parallaxScale); 
        float distY = (cam.transform.position.y * parallaxScale);

        transform.position = new Vector3(startposx + distX, startposy + distY, transform.position.z); 

        if (tempX > startposx + length) {
            startposx += length; 
        }
        else if (tempX < startposx - length) {
            startposx -= length;    
        }

    }
}