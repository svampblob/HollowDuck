﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbscript : MonoBehaviour
{
    public bool grabbed;
    public Transform holdpoint;
    public float throwpower = 15f;
    public GUNS equipped;
    public Movment move;
    public GameObject weapon;
    public Collider2D grabbablearea;
    public colliderONOF colllll;
    public bool ungrabbed;
    public float countdowntimer = 0f;
    public float maxscountdowntime = 1.5f;
    public bool thrown;
    public bool holdingHandGun;
    public bool holdingShotGun;
    public bool Shooting;

    void Start()
    {
        
        ungrabbed = false;
        
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Handgun")
        {
            print("Handgun");
            holdingHandGun = true;
        }
        if (collision.tag == "Shotgun")
        {
            print("Shotgun");
            holdingShotGun = true;
        }

        if (collision.tag == "grabbable")
        {   
            if (Input.GetButtonDown(move.Grabbkey + move.Player))
            {
               
                if (move)
                { 
                    if (!grabbed)
                    {
                        Grab(collision);
                        
                    }
                    
                    if (grabbed)
                    {
                        collision.gameObject.transform.position = holdpoint.position;
                    }
                    
                }
            }

        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        holdingShotGun = false;
        holdingHandGun = false;
    }

    void Update()
    {
        if(Shooting == true)
        {
            equipped.shooting = true;
        }
       
        if(grabbed == true)
        {
            grabbablearea.enabled = false;
        }
        if (ungrabbed == true)
        {
           
                countdowntimer += Time.deltaTime;
                if (countdowntimer > maxscountdowntime)
                {
                   
                    grabbablearea.enabled = true;
                    ungrabbed = false;
                    countdowntimer = 0f;
                }
            
        }
        
        
        if (Input.GetButtonDown(move.ungrabbed + move.Player) && grabbed == true)
        {
            unequiped();
        }
        if(Input.GetButtonDown(move.ShootingKey + move.Player))
        {
            
        }
    }

    private void unequiped()
    {
        if(Input.GetButtonDown(move.ungrabbed + move.Player))
        {
            move.holdingShotGun = false;
            move.holdingHandGun = false;
            holdingShotGun = false;
            holdingHandGun = false;
            countdowntimer = 0f;
            ungrabbed = true;
         
            weapon.GetComponent<colliderONOF>().move = true;
            weapon.GetComponent<colliderONOF>().holdingGun = false;
            equipped = null;
            if(ungrabbed == true)
            {
                if(move.right == true)
                {
                    if (weapon.transform.parent != null)
                    {
                        weapon.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 0.25f) * throwpower;
                        thrown = true;
                        weapon.transform.parent = null;

                    }
                    else
                    {
                        thrown = false;
                    }
                    grabbed = false;
                }
                if(move.right == false)
                {
                    throwpower = throwpower * -1;
                    if (weapon.transform.parent != null)
                    {
                        weapon.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 0.25f) * throwpower;
                        thrown = true;
                        weapon.transform.parent = null;

                    }
                    else
                    {
                        thrown = false;
                    }
                    grabbed = false;
                }
            }
            
        }
        
    }

    private void Grab(Collider2D collision)
    {
        
        if (holdingHandGun == true)
       {
            move.holdingHandGun = true;
       }
       if(holdingShotGun == true)
       {
            move.holdingShotGun = true;
       } 
       
        ungrabbed = false;
        grabbed = true;
        weapon = collision.gameObject;
        colllll = weapon.GetComponent<colliderONOF>();
        collision.GetComponent<colliderONOF>().move = false;
        collision.GetComponent<colliderONOF>().holdingGun = true;
        equipped = collision.GetComponent<GUNS>();
        collision.transform.parent = holdpoint;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Thrown")
        {
            ungrabbed = true;
            throwpower = 2f;
            weapon.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 0.25f) * throwpower;
        }
        if(ungrabbed == true)
        {
            throwpower = 12.5f;
        }
    }

}
