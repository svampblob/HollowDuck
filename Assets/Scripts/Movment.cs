using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movment : MonoBehaviour
{
    public bool holdingHandGun;
    public bool holdingShotGun;
    public bool holdingGrenade;
    public bool holdingRPG;
    public int Player;
    // Vareabel till Movefunction
    public float movespeed = 6f;
    public bool weapondirection;
    public bool moving;
    public bool right;
    public bool left;
    // vareabel till Jumpfunction
    public float Jumpspeed = 16f;
    public bool IsJumping;
    // Vareabler till crouch animation och crouch collider2D
    public Collider2D disablecollider2D;
    public Collider2D slidingcollider;
    public Collider2D idlecollider;
    // Vareabel till Grounchecker scriptet
    public Groundchecker groundcheck;
    // Hämtar Rigidbody
    private Rigidbody2D rbody;
    // Vareabel till Crouchfunction
    public bool Crouch;
    // Vareabel till crouchslidingfunction
    public bool sliding = false;
    public float slidingtimer = 0f;
    public float maxslidetime = 0.5f;
    public bool canslide;
    // Charcter Animator
    public Animator animator;
    // Keys to controllers
    public string jumpKey = "Jump";
    public string movekey = "MoveHorizontal";
    public string crouchkey = "Crouch";
    public string Grabbkey = "Grabbing";
    public string ShootingKey = "Fire";
    public string ungrabbed = "unGrabbed";
    public AudioSource Jump;
    public AudioSource Slide;
    public ShootingAnimation sp;
    public Grabbscript grab;
    public Armor arm;

    void Start()
    {
        slidingcollider.enabled = false;
        disablecollider2D.enabled = false;
        rbody = GetComponent<Rigidbody2D>();
        Crouch = false;
        arm = GetComponent<Armor>();
    }
    void Update()
    {
        Movefunction();
        Jumpfunction();
        Crouchfunction();
        CrouchGlidefunction();
        IsShooting();

    }

    public void Movefunction()
    {

        rbody.velocity = new Vector2(Input.GetAxisRaw(movekey + Player) * movespeed, rbody.velocity.y);


        if (Input.GetAxisRaw(movekey + Player) < 0)
        {


            transform.rotation = Quaternion.identity;
            transform.rotation = Quaternion.Euler(0, 180, 0);

            weapondirection = true;
            moving = true;
            left = true;
            right = false;
            if (holdingHandGun == true)
            {
                animator.SetBool("Gun_Run", true);
                animator.SetBool("Running", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Shotgun_Idle", false);
            }
            else
            {
                if (holdingShotGun == false && holdingGrenade == false)
                {
                    animator.SetBool("Gun_Run", false);
                    animator.SetBool("Running", true);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Idle_Handgun", false);
                }
            }
            if (holdingShotGun == true)
            {
                animator.SetBool("Shotgun_Run", true);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Running", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("Shotgun_Idle", false);
            }
            else
            {
                if (holdingHandGun == false && holdingGrenade == false)
                {
                    animator.SetBool("Running", true);
                    animator.SetBool("Gun_Run", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Shotgun_Run", false);
                    animator.SetBool("Shotgun_Idle", false);
                }

            }
            if(holdingGrenade == true)
            {
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Running", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("Shotgun_Idle", false);
                animator.SetBool("Grenade_Run", true);
                animator.SetBool("Grenade_Idle", false);
            }
            else
            {
                if(holdingHandGun == false && holdingShotGun == false)
                {
                    animator.SetBool("Running", true);
                    animator.SetBool("Gun_Run", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Shotgun_Run", false);
                    animator.SetBool("Shotgun_Idle", false);
                    animator.SetBool("Grenade_Run", false);
                    animator.SetBool("Grenade_Idle", false);
                }

            }
            if(holdingRPG == true)
            {
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Running", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("Shotgun_Idle", false);
                animator.SetBool("Grenade_Run", false);
                animator.SetBool("Grenade_Idle", false);
                animator.SetBool("RPG_RUn", true);
                animator.SetBool("RPG_Idle", false);
            }
            else
            {
                if(holdingGrenade == false && holdingHandGun == false && holdingShotGun == false && holdingRPG == false)
                {
                    animator.SetBool("Running", true);
                    animator.SetBool("Gun_Run", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Shotgun_Run", false);
                    animator.SetBool("Shotgun_Idle", false);
                    animator.SetBool("Grenade_Run", false);
                    animator.SetBool("Grenade_Idle", false);
                    animator.SetBool("RPG_RUn", false);
                }
            }
        }// Vänster
        if (Input.GetAxisRaw(movekey + Player) > 0)
        {
           

            transform.rotation = Quaternion.identity;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            weapondirection = false;
            moving = true;
            right = true;
            if (holdingHandGun == true)
            {
                animator.SetBool("Gun_Run", true);
                animator.SetBool("Running", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Shotgun_Idle", false);
            }
            else
            {
                if (holdingShotGun == false)
                {
                    animator.SetBool("Gun_Run", false);
                    animator.SetBool("Running", true);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Idle_Handgun", false);
                }
            }
            if (holdingShotGun == true)
            {
                animator.SetBool("Shotgun_Run", true);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Running", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("Shotgun_Idle", false);
            }
            else
            {
                if (holdingHandGun == false)
                {
                    animator.SetBool("Running", true);
                    animator.SetBool("Gun_Run", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Shotgun_Run", false);
                    animator.SetBool("Shotgun_Idle", false);
                }

            }
            if (holdingGrenade == true)
            {
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Running", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("Shotgun_Idle", false);
                animator.SetBool("Grenade_Run", true);
                animator.SetBool("Grenade_Idle", false);
            }
            else
            {
                if (holdingHandGun == false && holdingShotGun == false)
                {
                    animator.SetBool("Running", true);
                    animator.SetBool("Gun_Run", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Shotgun_Run", false);
                    animator.SetBool("Shotgun_Idle", false);
                    animator.SetBool("Grenade_Run", false);
                    animator.SetBool("Grenade_Idle", false);
                }

            }
            if(holdingRPG == true)
            {
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Running", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("Shotgun_Idle", false);
                animator.SetBool("Grenade_Run", false);
                animator.SetBool("Grenade_Idle", false);
                animator.SetBool("RPG_RUn", true);
                animator.SetBool("RPG_Idle", false);
            }
            else
            {
                if (holdingHandGun == false && holdingGrenade == false && holdingShotGun == false)
                {
                    animator.SetBool("Running", true);
                    animator.SetBool("Gun_Run", false);
                    animator.SetBool("Idle", false);
                    animator.SetBool("Shotgun_Run", false);
                    animator.SetBool("Shotgun_Idle", false);
                    animator.SetBool("Grenade_Run", false);
                    animator.SetBool("Grenade_Idle", false);
                    animator.SetBool("RPG_RUn", false);
                }
            }
        }// Höger
        if (Input.GetAxisRaw(movekey + Player) == 0)
        {
            moving = false;
            if (holdingHandGun == true)
            {

                animator.SetBool("Gun_Run", false);
                animator.SetBool("Running", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle_Handgun", true);
            }
            if (holdingShotGun == false && holdingHandGun == false && holdingRPG == false && holdingGrenade == false)
            {
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("Running", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Idle", true);

            }
            if (holdingShotGun == true)
            {
                animator.SetBool("Shotgun_Idle", true);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Running", false);
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle_Handgun", false);

            }
            if (holdingShotGun == false && holdingHandGun == false && holdingRPG == false && holdingGrenade == false)
            {

                animator.SetBool("Running", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Idle", true);
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Shotgun_Idle", false);
            }
           if(holdingGrenade == true)
            {
                animator.SetBool("Shotgun_Idle", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Running", false);
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("Grenade_Run", false);
                animator.SetBool("Grenade_Idle", true);
            }
           if(holdingShotGun == false && holdingHandGun == false && holdingRPG == false && holdingGrenade == false)
            {
                animator.SetBool("Running", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Idle", true);
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Shotgun_Idle", false);
                animator.SetBool("Grenade_Idle", false);
            }
            if (holdingRPG == true)
            {
                animator.SetBool("RPG_Idle", true);
                animator.SetBool("RPG_RUn", false);
                animator.SetBool("Shotgun_Idle", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Running", false);
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("Grenade_Run", false);
                animator.SetBool("Grenade_Idle", false);
            }
            else
            {
                if (holdingHandGun == false && holdingGrenade == false && holdingShotGun == false && holdingRPG == false)
                {
                    animator.SetBool("RPG_Idle", false);
                    animator.SetBool("Shotgun_Idle", false);
                    animator.SetBool("Gun_Run", false);
                    animator.SetBool("Running", false);
                    animator.SetBool("Shotgun_Run", false);
                    animator.SetBool("Idle", true);
                    animator.SetBool("Idle_Handgun", false);
                    animator.SetBool("Grenade_Run", false);
                    animator.SetBool("Grenade_Idle", false);
                }
            }
        }// Notmoving

        if (Input.GetAxisRaw(movekey + Player) < 0 && Input.GetButtonDown(crouchkey + Player))
        {
        
            
            if (groundcheck.isgrounded > 0)
            {
                print("sliding;");
                canslide = true;
                Slide.Play();
            }
            
        }
        if (Input.GetAxisRaw(movekey + Player) > 0 && Input.GetButtonDown(crouchkey + Player))
        {

            if (groundcheck.isgrounded > 0)
            {
                canslide = true;
                Slide.Play();
            }
        }

    }
    void Jumpfunction()
    {
        if (Input.GetButtonDown(jumpKey + Player))
        {

            if (groundcheck.isgrounded > 0)
            {
                rbody.velocity = new Vector2(rbody.velocity.x, Jumpspeed);
                Jump.Play();
           
            }
            
        }
        if (groundcheck.isgrounded == 0)
        {
            if (holdingHandGun == false)
            {
                canslide = false;
                Crouch = false;
                animator.SetBool("Running", false);
                animator.SetBool("Jump", true);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Idle_Handgun", false);
            }

            if (holdingHandGun == true)
            {
                animator.SetBool("Gun_Jump", true);
                animator.SetBool("Running", false);
                animator.SetBool("Jump", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("canslide", false);
            }
            if (holdingShotGun == true)
            {
                animator.SetBool("Gun_Jump", false);
                animator.SetBool("Running", false);
                animator.SetBool("Jump", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("canslide", false);
                animator.SetBool("Shotgun_Jump", true);
                animator.SetBool("Shotgun_Idle", false);

            }
            if(holdingGrenade == true)
            {
                animator.SetBool("Gun_Jump", false);
                animator.SetBool("Running", false);
                animator.SetBool("Jump", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("canslide", false);
                animator.SetBool("Shotgun_Jump", false);
                animator.SetBool("Shotgun_Idle", false);
                animator.SetBool("Grenade_Jump", true);
                animator.SetBool("Grenade_Idle", false);
                animator.SetBool("Grenade_Run", false);
            }
            if (holdingRPG == true)
            {
                animator.SetBool("Gun_Jump", false);
                animator.SetBool("Running", false);
                animator.SetBool("Jump", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("canslide", false);
                animator.SetBool("Shotgun_Jump", false);
                animator.SetBool("Shotgun_Idle", false);
                animator.SetBool("Grenade_Jump", false);
                animator.SetBool("Grenade_Idle", false);
                animator.SetBool("Grenade_Run", false);
                animator.SetBool("RPG_Jump", true);
                animator.SetBool("RPG_Idle", false);
                animator.SetBool("RPG_RUn", false);
            }
        }
        
        if (groundcheck.isgrounded == 1)
        {
            animator.SetBool("Gun_Jump", false);
            animator.SetBool("Jump", false);
            animator.SetBool("Shotgun_Jump", false);
            animator.SetBool("Grenade_Jump", false);
            animator.SetBool("RPG_Jump", false);
        }
    }
    void Crouchfunction()
    {
        if (Input.GetButtonDown(crouchkey + Player))
        {
            Crouch = true;

        }
        if (Input.GetButtonUp(crouchkey + Player))
        {
            Crouch = false;

        }
        if (Crouch == true)
        {

            disablecollider2D.enabled = true;
            idlecollider.enabled = false;
            movespeed = 0f;
            if(holdingHandGun == true)
            {
                animator.SetBool("Handgun_Crouch", true);
                animator.SetBool("Crouch", false);
                animator.SetBool("Idle_Handgun", false);
            }
            if(holdingHandGun == false)
            {
                if(holdingShotGun == false && holdingGrenade == false)
                {
                    animator.SetBool("Handgun_Crouch", false);
                    animator.SetBool("Crouch", true);
                    animator.SetBool("Idle_Handgun", false);
                    animator.SetBool("Grenade_Idle", false);
                    animator.SetBool("Grenade_Crouch", false);
                }
               
            }
            if (holdingShotGun == true)
            {
                animator.SetBool("Shotgun_Crouch", true);
                animator.SetBool("Crouch", false);
                animator.SetBool("Shotgun_Idle", false);
            }
            if (holdingShotGun == false)
            {
                if (holdingHandGun == false && holdingGrenade == false)
                {
                    animator.SetBool("Handgun_Crouch", false);
                    animator.SetBool("Crouch", true);
                    animator.SetBool("Idle_Handgun", false);
                    animator.SetBool("Grenade_Idle", false);
                    animator.SetBool("Grenade_Crouch", false);
                }

            }
            if(holdingGrenade == true)
            {
                animator.SetBool("Grenade_Idle", false);
                animator.SetBool("Crouch", false);
                animator.SetBool("Grenade_Crouch", true);
            }
            if(holdingGrenade == false)
            {
                if(holdingHandGun == false && holdingShotGun == false)
                {
                    animator.SetBool("Handgun_Crouch", false);
                    animator.SetBool("Crouch", true);
                    animator.SetBool("Idle_Handgun", false);
                    animator.SetBool("Handgun_Crouch", false);
                    animator.SetBool("Idle_Handgun", false);
                }
            }
            if (holdingRPG == true)
            {
                animator.SetBool("Crouch", false);
                animator.SetBool("RPG_Idle", false);
                animator.SetBool("RPG_Crouch", true);
            }
            if (holdingRPG == false)
            {
                if (holdingShotGun == false && holdingHandGun == false && holdingGrenade == false)
                {
                    animator.SetBool("Handgun_Crouch", false);
                    animator.SetBool("Crouch", true);
                    animator.SetBool("Idle_Handgun", false);
                    animator.SetBool("Handgun_Crouch", false);
                    animator.SetBool("Idle_Handgun", false);
                }
            }
        }
       
        if (Crouch == false)
        {
            movespeed = 6f;
            animator.SetBool("Crouch", false);
            animator.SetBool("Shotgun_Crouch", false);
            animator.SetBool("Handgun_Crouch", false);
            animator.SetBool("Grenade_Crouch", false);
            animator.SetBool("RPG_Crouch", false);
        }

    }
    void CrouchGlidefunction()
    {
        if (canslide == true)
        {
            sliding = true;
        }
        if (sliding == true)
        {
            movespeed = 12f;
        }
        if (sliding == true)
        {
            
            slidingtimer += Time.deltaTime;
            if (slidingtimer > maxslidetime)
            {
                sliding = false;
                movespeed = 0f;
                canslide = false;
                
            }
            if (sliding == false)
            {
                movespeed = 6f;
                slidingtimer = 0f;
            }
        }


        if (sliding == true)
        {
            if (canslide == true)
            {
                if (holdingHandGun == true)
                {
                    slidingcollider.enabled = true;
                    idlecollider.enabled = false;
                    Crouch = false;
                    animator.SetBool("Handgun_Slide", true);
                    animator.SetBool("Idle_Handgun", false);
                    animator.SetBool("canslide", false);
                    animator.SetBool("Running", false);
                    animator.SetBool("Gun_Run", false);
                    animator.SetBool("Shotgun_Slide", false);
                    animator.SetBool("Shotgun_Run", false);
                }
                else
                {
                    if (holdingShotGun == false)
                    {
                        animator.SetBool("Idle_Handgun", false);
                        animator.SetBool("canslide", true);
                        animator.SetBool("Running", false);
                        animator.SetBool("Gun_Run", false);
                        animator.SetBool("Shotgun_Slide", false);
                    }
                }
                if (holdingShotGun == true)
                {
                    slidingcollider.enabled = true;
                    idlecollider.enabled = false;
                    Crouch = false;
                    animator.SetBool("Idle_Handgun", false);
                    animator.SetBool("canslide", false);
                    animator.SetBool("Running", false);
                    animator.SetBool("Gun_Run", false);
                    animator.SetBool("Shotgun_Slide", true);
                    animator.SetBool("Shotgun_Run", false);
                    animator.SetBool("Handgun_Slide", false);
                }
                else
                {
                    if (holdingHandGun == false)
                    {
                        animator.SetBool("Idle_Handgun", false);
                        animator.SetBool("canslide", true);
                        animator.SetBool("Running", false);
                        animator.SetBool("Gun_Run", false);
                        animator.SetBool("Shotgun_Slide", false);
                    }

                }
                if(holdingGrenade == true)
                {
                    animator.SetBool("Idle_Handgun", false);
                    animator.SetBool("canslide", false);
                    animator.SetBool("Running", false);
                    animator.SetBool("Gun_Run", false);
                    animator.SetBool("Shotgun_Slide", false);
                    animator.SetBool("Shotgun_Run", false);
                    animator.SetBool("Handgun_Slide", false);
                    animator.SetBool("Grenade_Slide", true);
                    animator.SetBool("Grenade_Idle", false);
                    animator.SetBool("Grenade_Run", false);
                    animator.SetBool("Grenade_Crouch", false);
                }
                else
                {
                    if(holdingHandGun == false && holdingShotGun == false)
                    {
                        animator.SetBool("Idle_Handgun", false);
                        animator.SetBool("canslide", true);
                        animator.SetBool("Running", false);
                        animator.SetBool("Gun_Run", false);
                        animator.SetBool("Shotgun_Slide", false);
                        animator.SetBool("Idle_Handgun", false);
                        animator.SetBool("Running", false);
                        animator.SetBool("Gun_Run", false);
                        animator.SetBool("Shotgun_Slide", false);
                    } 
                }
                if(holdingRPG == true)
                {
                    animator.SetBool("Idle_Handgun", false);
                    animator.SetBool("canslide", false);
                    animator.SetBool("Running", false);
                    animator.SetBool("Gun_Run", false);
                    animator.SetBool("Shotgun_Slide", false);
                    animator.SetBool("Shotgun_Run", false);
                    animator.SetBool("Handgun_Slide", false);
                    animator.SetBool("Grenade_Slide", false);
                    animator.SetBool("Grenade_Idle", false);
                    animator.SetBool("Grenade_Run", false);
                    animator.SetBool("Grenade_Crouch", false);
                    animator.SetBool("RPG_Slide", true);
                    animator.SetBool("RPG_RUn", false);
                    animator.SetBool("RPG_Crouch", false);

                }
                else
                {
                    if(holdingGrenade == false && holdingHandGun == false && holdingShotGun == false)
                    {
                        animator.SetBool("Idle_Handgun", false);
                        animator.SetBool("canslide", true);
                        animator.SetBool("Running", false);
                        animator.SetBool("Gun_Run", false);
                        animator.SetBool("Shotgun_Slide", false);
                        animator.SetBool("Idle_Handgun", false);
                        animator.SetBool("Running", false);
                        animator.SetBool("Gun_Run", false);
                        animator.SetBool("Shotgun_Slide", false);
                        animator.SetBool("RPG_Slide", false);
                    }
                }
                    
            }

        }
        if (sliding == false)
        {
            if (canslide == false)
            {

                slidingcollider.enabled = false;
                if (arm.bulletproofVestIsOn == false)
                {
                    idlecollider.enabled = true;
                } 
                animator.SetBool("canslide", false);
                animator.SetBool("Shotgun_Slide", false);
                animator.SetBool("Handgun_Slide", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Grenade_Slide", false);
                animator.SetBool("RPG_Slide", false);
            }
        }


    }
    void IsShooting()
    {

        if (Input.GetButtonDown(ShootingKey + Player))
        {

            if (holdingHandGun == true)
            {
                grab.Shooting = true;
            }
            if (holdingShotGun == true)
            {
                grab.Shooting = true;
            }
            if(holdingRPG == true)
            {
                grab.Shooting = true;
            }
        }
        if (Input.GetButtonUp(ShootingKey + Player))
        {
            if (holdingHandGun == true)
            {
                grab.Shooting = false;
            }
            if (holdingShotGun == true)
            {
                grab.Shooting = false;
            }
            if(holdingRPG == true)
            {
                grab.Shooting = false;
            }
        }

    }
}

