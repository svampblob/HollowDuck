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

    public bool holdingGun;
    public bool ungrabbed;

    public float countdowntimer = 0f;
    public float maxscountdowntime = 1.5f;
    public bool grabbavlearea_ONOF = false;

    void Start()
    {
        
        ungrabbed = false;
        Player = move.Player;
        stringformat = move.Grabbkey;
        stringformat2 = move.ungrabbed;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {   
        if (collision.tag == "grabbable")
        {   
            if (Input.GetButtonDown(stringformat + Player))
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
        
        
        if (Input.GetButtonDown(stringformat2 + Player) && grabbed == true)
        {
            unequiped();
        }
    }

    private void unequiped()
    {
        move.holdingGun = false;
        countdowntimer = 0f;
        ungrabbed = true;
        weapon.GetComponent<colliderONOF>().move = true;
        equipped = null;
        weapon.transform.parent = null;
        if (weapon.transform.parent = null)
        {
            weapon.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwpower;
        }
        grabbed = false;
    }

    private void Grab(Collider2D collision)
    {
        move.holdingGun = true;
        ungrabbed = false;
        grabbed = true;
        weapon = collision.gameObject;
        collision.GetComponent<colliderONOF>().move = false;
        equipped = collision.GetComponent<Gun>();
        collision.transform.parent = holdpoint;

    }

}
