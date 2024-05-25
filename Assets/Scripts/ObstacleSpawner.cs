using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject spawnee;
    public float spawnRate = 2;
    private float timer = 0.0f;

    void Start() {
        // TODO: start this only when we get past the cutscene and stop when we make it past the spawner
    }

    void Update()
    {
        if (timer < spawnRate){
            timer += Time.deltaTime;
        }
        else{
            timer = 0.0f;
            var r = GetComponent<Renderer>();
            if (r == null){
                Debug.Log("No renderer found");
                return;
            }
            var bounds = r.bounds;
            float y = (float) 0.48 * bounds.size.y;

            Vector3 newPos = new Vector3(transform.position.x, Random.Range(transform.position.y - y, transform.position.y + y), transform.position.z);
            Instantiate(spawnee, newPos, transform.rotation);
        }
    }
}