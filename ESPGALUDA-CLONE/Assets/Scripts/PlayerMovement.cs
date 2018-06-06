using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour, IPlayer {
    // Players localposition variable
    public Vector3 localPos;

    // Create Variables.

    public Rigidbody Rb;
    //public bool LaserGun = false;
    float Speed;
    public float normalSpeed;
    public float slowSpeed;
    public float XMax;
    public float XMin;
    public float ZMax;
    public float ZMin;

    //public float origHP;
    //public float Hitpoints;
    public float Lives;
    public float Crystals;
    private SpriteRenderer PlaneRenderer;
    
    //public float laserTimer;
    PlayerShooting ps;

    public int expl;

    bool invincible;

    public float Tilt;
    public float turnSpeed;

    public float RendererTimer;
    public float MaxRendererTimer;

    public float invincibleTimer;
    public float invincibilityTime;
    public float invispeed;
    public float deathTimer;

    public string deathAudioEvent;
    public string playerHitAudioEvent;

    bool Invincible() {
        return invincibleTimer > 0;
    }



    public void PlayerHit(float dmg) {
        GameManager.instance.Explosion(2, transform);
        Fabric.EventManager.Instance.PostEvent(playerHitAudioEvent);
        // if (Invincible()) {
        //   GetComponentInChildren<BoxCollider>().enabled = false;
        //} else { GetComponentInChildren<BoxCollider>().enabled = true;}
        if (!Invincible()) {
            invincibleTimer = invincibilityTime;
            GameManager.instance.LifeLost();
            //Hitpoints -= dmg;

          
        }

       
        //else if (UnRendererTimer > RendererTimer)
        //{
        //    PlaneRenderer.enabled = true;
        //}

        //  invincible = true;
        //invincibleTimer += Time.deltaTime;
        //if (invincibleTimer < invincibleTickTime) {
        //  invincible = false;
        //}
        //if (Hitpoints == 0) {
        //Hitpoints = origHP;
        //GameManager.instance.LifeLost();
        if (Lives <= 0) {
                Fabric.EventManager.Instance.PostEvent(deathAudioEvent);
                GameManager.instance.Explosion(expl, transform);
                GetComponentInChildren<SpriteRenderer>().enabled = false;
                GameManager.instance.PlayerDead();
                //GetComponentInChildren<BoxCollider>().enabled = false;
                //deathTimer += Time.unscaledDeltaTime * 5;
                if (deathTimer >= 1.5f) {
                GameManager.instance.AudioStop();
                SceneManager.LoadScene("GameOver");
            }
            }
    }
   

    //public void Blinking(float BlinkingTimer)
    //{
    //    for (int o = 0; o < BlinkingTimer; o++)
    //    {
    //        PlaneRenderer.enabled = !PlaneRenderer.enabled;
    //        //coroutine = WaitAndPrint(2.0f);
    //        BlinkingTimer = 0.2f;
    //        RendererTimer = BlinkingTimer;
    //    }
    //}
    //}


    public void OnTriggerEnter(Collider other) { {
            if (other.gameObject.layer == LayerMask.NameToLayer("Flying Enemies")) {
                PlayerHit(1);
                GameManager.instance.Explosion(expl, other.transform);
                Destroy(other.gameObject);
            }
        }
    }

    // Perform it on game start. Create Player ship's Rigidbody. 
    void Start()
    {
        //origHP = Hitpoints;
        Rb = GetComponent<Rigidbody>();
        
        localPos = transform.position - World.center.position;

        //laserTimer = GetComponent<PlayerShooting>().laserTimer;
        ps = GetComponent<PlayerShooting>();
        PlaneRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void GainCrystal () {
        Crystals += 1;
    }


    void Update() {
        if (Lives <= 0) {
            deathTimer += Time.unscaledDeltaTime / 2;
        }
        if (Lives >= 1)
        if (invincibleTimer > 0) {
            invincibleTimer -= Time.unscaledDeltaTime;
            PlaneRenderer.enabled = ((int)(invincibleTimer * 8) % 2 == 0);
            GetComponentInChildren<BoxCollider>().enabled = false;
        }
        else {
            if (Lives >= 1)
            invincibleTimer = 0;
            PlaneRenderer.enabled = true;
            GetComponentInChildren<BoxCollider>().enabled = true;
        }
        Crystals = Mathf.Clamp(Crystals, 0, 500);

        if (Crystals >= 500) {
            Crystals = 500;
        }
        if (Crystals <= 0) {
            Crystals = 0;
        }
        //if (invincibleTimer < 0) {
        //    invincibleTimer = 0;
        //}
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
        localPos += moveDir.normalized * Time.unscaledDeltaTime * Speed;
        Movingbounds();
        transform.position = World.center.position + localPos;




        // Checked bool.


        if (ps.MovementSlowdown())
        {
        Speed = slowSpeed; // Player Movement should be Slower.
        // print("Hidastuu");

        } else {
        Speed = normalSpeed; // Player Movement should be Faster.
        //print("Nopeutta lisää");
        }


        //Move();
        //X360Move();


    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.unscaledDeltaTime);
            print("Liikkuu oikealle");

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            transform.Translate(Vector3.right * 0f);
        }


        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.unscaledDeltaTime);
            print("Liikkuu vasemmalle");
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.Translate(Vector3.left * 0f);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.unscaledDeltaTime);
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

        Vector3 XPASS = transform.TransformDirection(new Vector3(hAxis, 0, vAxis) * Speed * Time.unscaledDeltaTime);

        Rb.MovePosition(transform.position + XPASS);

        Quaternion rotation = Quaternion.Euler(new Vector3(0, rStickX, 0) * turnSpeed * Time.unscaledDeltaTime);

        transform.Rotate(new Vector3(0, rStickX, 0), turnSpeed * Time.unscaledDeltaTime);
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




