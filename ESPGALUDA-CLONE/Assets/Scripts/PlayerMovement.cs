﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    // Create Variables.

    public Rigidbody Rb;
    public float Speed;
    public float turnSpeed;



    // Perform it on game start. Create Player ship's Rigidbody. 
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        //Vector3  (movement = new Vector3 (0,0,10f * Speed) * Time.deltaTime);
        
        // Perform it on all time. Player Moving.
        Vector3 Movement = new Vector3(0, 0, 0.6f * Speed) * Time.deltaTime;
        Rb.MovePosition(transform.position + Movement);

        Move();
        X360Move();

    }

   public void Move()
    {
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * 0.1f);

        }

        if (Input.GetKeyUp("d"))
        {
            transform.Translate(Vector3.right * 0f);
        }


        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * 0.1f);
        }

        if (Input.GetKeyUp("a"))
        {

            transform.Translate(Vector3.left * 0f);

        }

        if (Input.GetKey("s"))
        {
           transform.Translate(Vector3.back * 0.1f);
        }

        if (Input.GetKeyUp("s"))
        {
            transform.Translate(Vector3.back * 0f);

        }

    }

    public void X360Move()
    {

        float dPadX = Input.GetAxis("X360_DPadX");

        float dPadY = Input.GetAxis("X360_DPadY");

        float triggerAxis = Input.GetAxis("X360_Triggers");

        if (dPadX != 0)
        {
            print("DPad Horizontal Value: " + dPadX);
        }
        if (dPadY != 0)
        {
            print("DPad Vertical Value: " + dPadY);
        }
        if (triggerAxis != 0)
        {
            print("Trigger Value: " + triggerAxis);
        }
        if (Input.GetButtonDown("X360_LBumper"))
        {
            print("Left Bumper");
        }
        if (Input.GetButtonDown("X360_RBumper"))
        {
            print("Right Bumper");
        }
        if (Input.GetButtonDown("X360_A"))
        {
            print("A Button");
        }
        if (Input.GetButtonDown("X360_B"))
        {
            print("B Button");
        }
        if (Input.GetButtonDown("X360_X"))
        {
            print("X Button");
        }
        if (Input.GetButtonDown("X360_Y"))
        {
            print("Y Button");
        }
        if (Input.GetButtonDown("X360_Back"))
        {
            print("Back Button");
        }
        if (Input.GetButtonDown("X360_Start"))
        {
            print("Start Button");
        }
        if (Input.GetButtonDown("X360_LStickClick"))
        {
            print("Clicked Left Stick");
        }
        if (Input.GetButtonDown("X360_RStickClick"))
        {
            print("Clicked Right Stick");
        }



        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        float rStickX = Input.GetAxis("X360_RStickX");

        Vector3 XPASS = transform.TransformDirection(new Vector3(hAxis, 0, vAxis) * Speed * Time.deltaTime);

        Rb.MovePosition(transform.position + XPASS);

        Quaternion rotation = Quaternion.Euler(new Vector3(0, rStickX, 0) * turnSpeed * Time.deltaTime);

        transform.Rotate (new Vector3(0, rStickX, 0) * turnSpeed * Time.deltaTime);

    }

}




