using UnityEngine;

public class CameraFollow : MonoBehaviour {
    private Transform player;
    public float smoothSpeed = 6.0f;
    public float verticalOffset = 1.8f;

    public float orthographicSize = 6;

    
    void Start() {
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null) {
            player = playerObject.transform;
        } else {
            Debug.LogError("Player not found");
        }

        GetComponent<Camera>().orthographicSize = orthographicSize;
    }
    void Update() {
        Vector3 newPosition = new Vector3(player.position.x, player.position.y + verticalOffset, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
    
        
