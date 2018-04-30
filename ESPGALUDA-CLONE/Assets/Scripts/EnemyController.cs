using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    float timer;
    public float endChase;
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
        timer += Time.deltaTime;
        print(timer);
        float movement = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(oldPosition.position, newPosition.position, movement);

        if(oldPosition.position == newPosition.position) {
            waypoints.RemoveAt(0);
            if(waypoints == null) {
                
            }
        }
        //if(timer > ) {
            
        }




    

        //for (int i = 0; i < waypoints.Count; i++) {
            //if (oldPosition.position == newPosition.position) {
                //Destroy(waypoints[i]);
               // waypoints.RemoveAt(0/*i*/);
           // newPosition = enemy.transform;
                //newPosition = waypoints[i].transform;
               // if(timer >= 10) {
              //  waypoints.RemoveAt(0);
                
            }

            //}
            
        //}
    //}
//}