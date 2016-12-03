using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        //private float doubleJumpForce = 400f;
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;

        private bool CanDoubleJump;


        public GameObject spawnlazor;

        GameObject BulletGreen;

        bool IsAlive = false;

        public int AmmoLimit = 20;
        bool IsAmmo = false;


        bool SuperShot = false;
        float SuperShotAmmo = 900;

        public float PlayerHealth = 100;

        bool CanShoot;


        public GameObject DamageSpawn;

        public GameObject RocketDamage;

        GameObject GreenLazor;


        

        int jumps;
        public int maxJumps;

        // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.

       public static bool Right = false;
       public static bool Left = false;



        
        private bool IsJumping = false;
        private bool Onwall = false;


        void Start()
        {
            jumps = maxJumps;

            //when the game starts define what our declared gameobject will be by grabing it out of the resouces folder
            BulletGreen = Resources.Load("gBullet") as GameObject;

            //special bullet
            GreenLazor = Resources.Load("green_lazer") as GameObject;
        }

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);


        }


        public void Move(float move, bool crouch, bool jump)
        {
            // If crouching, check to see if the character can stand up
            if (!crouch && m_Anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }

            // Set whether or not the character is crouching in the animator
            m_Anim.SetBool("Crouch", crouch);

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move*m_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce *2));
                m_JumpForce = 400;
              
                
            }
            //-----------------------------------------------------------------------------------
            //shoot when facing directions
            if (m_FacingRight == true && Input.GetKeyDown(KeyCode.E) && CanShoot)
            {
               // Debug.Log("right");
                Right = true;

                //shoot the bullet
               // Debug.Log("i have shot the bullet");

                GameObject gbullet = Instantiate(BulletGreen) as GameObject;


                //shoots to the right
                gbullet.transform.position = transform.position + transform.right * .5f;

                Rigidbody2D rb = gbullet.GetComponent<Rigidbody2D>();
                rb.velocity = transform.right * 10;

                AmmoLimit--;
            }
            else
            {
                if (!m_FacingRight && Input.GetKeyDown(KeyCode.E) && CanShoot)
                {
                    Debug.Log("Left");
                    Left = true;
                    GameObject gbullet = Instantiate(BulletGreen) as GameObject;

                    gbullet.transform.Rotate(0, 0, 180);


                    //shoots to the left
                    gbullet.transform.position = transform.position + transform.right * -.5f;

                    Rigidbody2D rb = gbullet.GetComponent<Rigidbody2D>();
                    rb.velocity = transform.right * -10;


                    AmmoLimit--;

                }

                    //lazor test
                //---------------------------------------------------------
                if (Input.GetKeyDown(KeyCode.Q) && Right && SuperShot == true)
                {
                    GameObject lazor = Instantiate(GreenLazor) as GameObject;

                    lazor.transform.position = transform.position + transform.right * .5f;


                    Rigidbody2D Rbv = lazor.GetComponent<Rigidbody2D>();

                    Rbv.velocity = transform.right * 200;
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Q) && Left && SuperShot == true)
                    {
                        GameObject lazor = Instantiate(GreenLazor) as GameObject;

                        lazor.transform.position = transform.position + transform.right * -.5f;


                        Rigidbody2D Rbv = lazor.GetComponent<Rigidbody2D>();

                        Rbv.velocity = transform.right * 200;
                    }
                }

                //---------------------------------------------------------------------------

            }
           

        }


        void Update()
        {
            //------------------------------------------------------------
            //health system

            if (PlayerHealth <= 0)
            {
                Destroy(gameObject);
                IsAlive = false;
            }
            else
            {
                if (PlayerHealth >= 0)
                {
                    IsAlive = true;
                }
            }

//------------------------------
            if (AmmoLimit <= 0)
            {
                CanShoot = false;
            }
            else
            {
                if (AmmoLimit >= 0)
                {
                    CanShoot = true;
                }
            }


            if(SuperShotAmmo >= 1)
            {
                SuperShot = true;
            }
            else
            {
                if(SuperShotAmmo <= 0)
                {
                    SuperShot = false;
                }
            }

        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }


        void OnTriggerEnter2D(Collider2D colli)
        {
            //collect ammo if collide with item that gives ammo
            if (colli.gameObject.tag == "AmmoUp")
            {
                AmmoLimit += 10;
            }
            else
            {
                if(colli.gameObject.tag == "GreenAmmo")
                {
                    SuperShotAmmo++;
                }
            }

            //lose varrying health depending on what the enemy hits the player with
            if (colli.gameObject.tag == "EBullet")
            {
                //do basic damage
                PlayerHealth--;
            }
            else
            {
                if (colli.gameObject.tag == "ERocket")
                {
                    //do extra damage 
                    PlayerHealth -= 10;
                    //instantiate a particle
                    GameObject rockethit = Instantiate(RocketDamage, DamageSpawn.transform.position, Quaternion.identity) as GameObject;

                    //parent fire1 to enemybody
                    rockethit.transform.parent = gameObject.transform;

                }
            }
        }
	
	
	
	}
}
