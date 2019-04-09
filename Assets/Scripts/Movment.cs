using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movment : MonoBehaviour
{
    public bool holdingHandGun;
    public bool holdingShotGun;
    public int Player;
    // Vareabel till Movefunction
    public float movespeed = 6f;
    public bool weapondirection;
    public bool moving;
    public bool right;
    public bool left;
    // vareabel till Jumpfunction
    public static float Jumpspeed = 15f;
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

    public ShootingAnimation sp;
    public Grabbscript grab;

    void Start()
    {
        slidingcollider.enabled = false;
        disablecollider2D.enabled = false;
        rbody = GetComponent<Rigidbody2D>();
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


            transform.rotation = Quaternion.identity;
            transform.rotation = Quaternion.Euler(0, 180, 0);

            weapondirection = true;
            moving = true;
            left = true;
            right = false;
            sp.left = true;
            sp.right = false;
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

        }// Vänster
        if (Input.GetAxisRaw(movekey + Player) > 0)
        {


            transform.rotation = Quaternion.identity;
            transform.rotation = Quaternion.Euler(0, 0, 0);

            weapondirection = false;
            moving = true;
            right = true;
            sp.right = true;
            sp.left = false;

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
            if (holdingHandGun == false)
            {
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
            if (holdingShotGun == false)
            {

                animator.SetBool("Running", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Idle", true);
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Shotgun_Idle", false);
            }
            if (moving == false)
            {
                animator.SetBool("Running", false);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Idle", false);
                animator.SetBool("Shotgun_Run", false);
                animator.SetBool("Shotgun_Idle", false);
            }
        }

        if (Input.GetAxisRaw(movekey + Player) < 0 && Input.GetButtonDown(crouchkey + Player))
        {
            canslide = true;
        }
        if (Input.GetAxisRaw(movekey + Player) > 0 && Input.GetButtonDown(crouchkey + Player))
        {
            canslide = true;
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
                animator.SetBool("canslide", true);
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
            if (holdingShotGun == false)
            {
                canslide = false;
                Crouch = false;
                animator.SetBool("Running", false);
                animator.SetBool("Jump", true);
                animator.SetBool("Gun_Run", false);
                animator.SetBool("Idle_Handgun", false);
                animator.SetBool("canslide", false);
                animator.SetBool("Idle", false);
            }

        }
        if (groundcheck.isgrounded == 1)
        {
            animator.SetBool("Gun_Jump", false);
            animator.SetBool("Jump", false);
            animator.SetBool("Shotgun_Jump", false);
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
            if (holdingShotGun == true)
            {
                animator.SetBool("Shotgun_Crouch", true);
                animator.SetBool("Crouch", false);
                animator.SetBool("Shotgun_Idle", false);
            }
        }
        if (Crouch == false)
        {
            idlecollider.enabled = true;
            disablecollider2D.enabled = false;
            movespeed = 6f;
            animator.SetBool("Crouch", false);
            animator.SetBool("Shotgun_Crouch", false);
            animator.SetBool("Handgun_Crouch", false);
        }

    }
    void CrouchGlidefunction()
    {
        if (canslide == true)
        {
            sliding = true;
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

            }

        }
        if (sliding == false)
        {
            if (canslide == false)
            {

                slidingcollider.enabled = false;
                idlecollider.enabled = true;
                animator.SetBool("canslide", false);
                animator.SetBool("Shotgun_Slide", false);
                animator.SetBool("Handgun_Slide", false);
                animator.SetBool("Idle", false);
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
        }

    }
}

