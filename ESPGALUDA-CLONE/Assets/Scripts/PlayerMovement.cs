﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    // Players localposition variable and Cameras CameraObject variable.
    public Transform playfieldCenter;
    public Vector3 localPos;

    // Create Variables.

    public Rigidbody Rb;
    public float Speed;
    public float XMax;
    public float XMin;
    public float ZMax;
    public float ZMin;

    public float Tilt;
    public float turnSpeed;

    


    // Perform it on game start. Create Player ship's Rigidbody. 
    void Start()
    {
        Rb = GetComponent<Rigidbody>();

        playfieldCenter = GameObject.Find("CameraObject").transform;
        localPos = transform.position - playfieldCenter.position;
    }

    void Update()
    {
        //Vector3  (movement = new Vector3 (0,0,10f * Speed) * Time.deltaTime);

        // Perform it on all time. Player Moving.
        //Vector3 Movement = new Vector3(0, 0, 10 * Speed) * Time.deltaTime;
        //Rb.MovePosition(transform.position + Movement);

        // stays in place on screen if localPos is not changed

        //localPos = localPos + transform.forward * Time.deltaTime * Speed;
        //localPos = localPos + transform.position + Movement * Time.deltaTime * Speed;
        //localPos = localPos + Movement * Time.deltaTime * Speed;
        //localPos = localPos + transform.position * Speed * Time.deltaTime;
        //localPos = localPos + transform.position * Time.deltaTime * Speed;
        var moveDir = Input.GetAxis("Horizontal") * Vector3.right +
                        Input.GetAxis("Vertical") * Vector3.forward;
        localPos += moveDir.normalized * Time.deltaTime * Speed;
        Movingbounds();
        transform.position = playfieldCenter.position + localPos;


        //Move();
        //X360Move();
        
        
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime);
            print("Liikkuu oikealle");

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            transform.Translate(Vector3.right * 0f);
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime);
            print("Liikkuu vasemmalle");
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.Translate(Vector3.left * 0f);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.S))
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
            //print("Right Bumper");
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

        transform.Rotate(new Vector3(0, rStickX, 0), turnSpeed * Time.deltaTime);
    }


    public void Movingbounds()
    {
        localPos = new Vector3 // Liikkumisen rajoituset! ↧↧↧
        (
            //Mathf.Clamp(GetComponent<Rigidbody>().position.x, XMin, XMax), // X Akselin rajat.
            //0.0f,
            //Mathf.Clamp(GetComponent<Rigidbody>().position.z, ZMin, ZMax) // Z Akselin rajat.

            Mathf.Clamp(localPos.x, XMin, XMax), // X Akselin rajat.
            0.0f,
            Mathf.Clamp(localPos.z, ZMin, ZMax) // Z Akselin rajat.
        );
    }
    
}




