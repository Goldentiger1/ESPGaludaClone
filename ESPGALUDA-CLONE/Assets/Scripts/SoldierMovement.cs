using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{

    public float speed;
    //public List<GameObject> waypoints = new List<GameObject>();
    public Vector3 target;
    private Transform player;
    float timer;
    public float waitToShoot;




    void Start()
    {
        //waypoints = GetComponentInChildren<GameObject>();
        player = GameManager.instance.player.transform;
       
    }

    void Update()
    {
        timer += Time.deltaTime;
        float movement = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, movement);

        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            Vector3 targetDirection = player.position - transform.position;
            targetDirection.y = 0;
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, Time.deltaTime * 180);
            if (timer >= waitToShoot)
            {
                GetComponent<SoldierShooting>().enabled = true;
                
            }

            if (GameManager.instance.gameState == GameState.Kakusei)
            {
                waitToShoot = 2;
            }

            else
            {
                waitToShoot = 6;
            }
        }          
            
            
    }

        
}

