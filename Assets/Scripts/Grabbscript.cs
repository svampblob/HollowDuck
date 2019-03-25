using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbscript : MonoBehaviour
{
    public bool grabbed;
    public float distanceX = 2f;
    public Transform holdpoint;
    public float throwpower = 15f;
    public LayerMask notgrabbed;

    private Gun equipped;
    public Movment move;
    public ShootingAnimation SA;
    public int Player;
    public string stringformat;
    public string stringformat2;
    public bool grab;


    public GameObject weapon;
    public Collider2D grabbablearea;
    public Collider2D gunarea;

    public bool holdingGun;
    public bool ungrabbed;

    public float countdowntimer = 0f;
    public float maxscountdowntime = 1.5f;
    public bool grabbavlearea_ONOF = false;
    public bool thrown;

    void Start()
    {
        
        ungrabbed = false;
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {   
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

    void Update()
    {
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
    }

    private void unequiped()
    {
        if(Input.GetButtonDown(move.ungrabbed + move.Player))
        {
            
            move.holdingGun = false;
            countdowntimer = 0f;
            ungrabbed = true;
            weapon.GetComponent<colliderONOF>().move = true;
            weapon.GetComponent<colliderONOF>().holdingGun = false;
            equipped = null;
            if(ungrabbed == true)
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
            
        }
        
    }

    private void Grab(Collider2D collision)
    {
       
        move.holdingGun = true;
        ungrabbed = false;
        grabbed = true;
        weapon = collision.gameObject;
        collision.GetComponent<colliderONOF>().move = false;
        collision.GetComponent<colliderONOF>().holdingGun = true;
        equipped = collision.GetComponent<Gun>();
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
