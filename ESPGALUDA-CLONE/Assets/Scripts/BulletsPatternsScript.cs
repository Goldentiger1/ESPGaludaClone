using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BulletPatterns
{
    Nothing,
    Regular,

}

public class BulletsPatternsScript : MonoBehaviour
{
    public BulletPatterns Patterns;
    public Transform bossPosition;
    public Transform playerPosition;
    public bool fired = true;

    void Start()
    {
        bossPosition = GetComponent<Transform>();
        playerPosition = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector3.Distance(bossPosition.position, playerPosition.position) < 8f)
        {

        }
    }
}