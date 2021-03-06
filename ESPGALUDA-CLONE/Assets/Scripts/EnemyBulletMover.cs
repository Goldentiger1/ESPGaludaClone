﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMover : MonoBehaviour {

    public float speed;
    public float speednumber;
    public float destroytime;

    public Vector3 localPos;

    //public Sprite normal;
    //public Sprite kakusei;
    //public Sprite kakuseiover;

    //public SpriteRenderer spriter;

    Animator animator;

    void Start() {
        //playfieldCenter = GameObject.Find("CameraObject").transform;
        localPos = transform.position - World.center.position;
        Destroy(gameObject, destroytime);
        //spriter = GetComponentInChildren<SpriteRenderer>();
        
    }

    void Awake() {
        animator = GetComponentInChildren<Animator>();
    }

    void Update() {
        var speedFactor = (GameManager.instance.gameState == GameState.KakuseiOver) ? speednumber : 1f;
        localPos = localPos + transform.forward * Time.deltaTime * speed * speedFactor;
        transform.position = World.center.position + localPos;

        //if (GameManager.instance.gameState == GameState.KakuseiOver) {
        //    speed *= 1.2f;
        //}
        if (GameManager.instance.gameState == GameState.Kakusei) {
            animator.Play("Ebullet2");
            //spriter.sprite = kakusei;
        } else if (GameManager.instance.gameState == GameState.KakuseiOver) {
            animator.Play("Ebullet3");
            //spriter.sprite = kakuseiover;
        } else {
            //spriter.sprite = normal;
            animator.Play("Ebullet1");
        }

    }
}

