using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float speed;
    public GameObject enemy;
    Transform oldPosition;
    Transform newPosition;

    public List<GameObject> waypoints = new List<GameObject>();

    void Start() {
        oldPosition = GetComponent<Transform>();
        newPosition = waypoints[0].transform;
    }

    void Update() {
        float movement = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(oldPosition.position, newPosition.position, movement);

        for (int i = 0; i < waypoints.Count; i++) {
            if (oldPosition.position == newPosition.position) {
                Destroy(waypoints[i]);
                waypoints.RemoveAt(i);
                newPosition = waypoints[i].transform;
            }
        }
    }
}

/* Waypoints listan läpikäynti
* Pitää tehdä vielä loppuun
     
void GoThroughListInOrder(List<GameObject> a) {
foreach(GameObject i in a) {
if(i == null) {

}
}
}
*/
