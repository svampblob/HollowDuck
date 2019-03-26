using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movment : MonoBehaviour
{
    public bool holdingGun;
    public int Player;
    public bool Is_Shooting;
    // Vareabel till Movefunction
    public static float movespeed = 6f;
    public bool weapondirection;
    public bool moving;
    // vareabel till Jumpfunction
    public static float Jumpspeed = 15f;
    public bool jump;
    // Vareabler till crouch animation och crouch collider2D
    public Sprite Deafult;
    public Sprite Crouchsprite;
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
    public bool islsiding;
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

    public Gun equipped;
    public Grabbscript grab;

    public bool grabbed;
    public bool Shooting;

    void Start()
    {
        slidingcollider.enabled = false;
        disablecollider2D.enabled = false;
        rbody = GetComponent<Rigidbody2D>();
        gameObject.GetComponent<SpriteRenderer>().sprite = Deafult;
        Crouch = false;

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

            transform.localScale = new Vector3(-1f, 1f, 1f);
            transform.rotation = Quaternion.identity;
            weapondirection = true;
            moving = true;
            animator.SetBool("Running", true);
            if(holdingGun == true)
            {
                animator.SetBool("Gun_Run", true);
                animator.SetBool("Running", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Idle_Handgun", false);
            }
            if(holdingGun == false)
            {
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Running", true);
                animator.SetBool("Gun_Run", false);
            }
        }// Vänster
        if (Input.GetAxisRaw(movekey + Player) > 0)
        {

            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.rotation = Quaternion.identity;
            weapondirection = false;
            moving = true;
            animator.SetBool("Running", true);
        }// Höger
        if(Input.GetAxisRaw(movekey + Player) == 0)
        {
            moving = false;
            if (holdingGun == true)
            {
                animator.SetBool("Idle_Handgun", true);
                
            }
            else
            {
                animator.SetBool("Idle_Handgun", false);

                holdingGun = false;
            }
            if (holdingGun == false)
            {
                animator.SetBool("Idle", true);
            }
            animator.SetBool("Running", false);
        }

        if (Input.GetAxisRaw(movekey + Player) < 0 && Input.GetButtonDown(crouchkey + Player))
        {
            canslide = true;
        }
        if (Input.GetAxisRaw(movekey + Player) > 0 && Input.GetButtonDown(crouchkey + Player))
        {
            canslide = true;
        }
        if (Input.GetButtonUp(crouchkey + Player))
        {
            //canslide = false;
        }
    }
    void Jumpfunction()
    {
        if (Input.GetButtonDown(jumpKey + Player))
        {

            if (groundcheck.isgrounded > 0)
            {
                rbody.velocity = new Vector2(rbody.velocity.x, Jumpspeed);

            }

        }
        if (groundcheck.isgrounded == 0)
        {
            canslide = false;
            Crouch = false;
            animator.SetBool("Running", false);
            animator.SetBool("Jump", true);
            animator.SetBool("Gun_Run", false);
            animator.SetBool("Idle_Handgun", false);
            animator.SetBool("canslide", true);
           

        }
        if (groundcheck.isgrounded == 1)
        {
            animator.SetBool("Jump", false);
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
            animator.SetBool("Crouch", true);
        }
        if (Crouch == false)
        {
            idlecollider.enabled = true;
            disablecollider2D.enabled = false;
            movespeed = 6f;
            animator.SetBool("Crouch", false);
        }
      
    }
    void CrouchGlidefunction()
    {
        if (canslide == true)
        {

            
            sliding = true;

            Movment.movespeed = 12f;
        }
        if (sliding == true)
        {
            slidingtimer += Time.deltaTime;
            if (slidingtimer > maxslidetime)
            {
                sliding = false;
                Movment.movespeed = 0f;
                canslide = false;
            }
            if (sliding == false)
            {
                Movment.movespeed = 6f;
                slidingtimer = 0f;
            }
        }


        if (sliding == true)
        {
            if (canslide == true)
            {
                animator.SetBool("Idle_Handgun", false);
                slidingcollider.enabled = true;
                idlecollider.enabled = false;
                Crouch = false;
                animator.SetBool("canslide", true);
                animator.SetBool("Running", false);
                animator.SetBool("Gun_Run", false);
            }

        }
        if (sliding == false)
        {
            if (canslide == false)
            {
                
                slidingcollider.enabled = false;
                idlecollider.enabled = true;
                animator.SetBool("canslide", false);
            }
        }


    }
    void IsShooting()
    {
        if (Input.GetButtonDown(ShootingKey + Player))
        {
            if(holdingGun == true)
            {
                equipped.IsShooting = true;
            }
            
        }
        if (Input.GetButtonUp(ShootingKey + Player))
        {
            if(holdingGun == true)
            {
                equipped.IsShooting = false;
            }
           
        }
    }
   
}

