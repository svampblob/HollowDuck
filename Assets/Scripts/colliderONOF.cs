using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderONOF : MonoBehaviour {
    public Collider2D dissablecollider2d;
    public Rigidbody2D rbody2;
    public bool move;
    public Movment movement;
    public SpriteRenderer sp;
    public Collider2D gunarea;
    public bool holdingGun;
    public int Ammo = 1;
    public bool shooting;
    public bool Ammoo;
    public bool thrown;
    public bool droppweapon;
    public bool Player1;
    public bool Player2;
    public bool Player3;
    public bool Player4;
    public bool touchedplayer;
    public float countdowntimer = 0f;
    private float maxscountdowntime = 1f;
    public float countdowntimer1 = 0f;
    private float maxscountdowntime1 = 0.25f;

    void Start()
    {
        thrown = false;
        dissablecollider2d.enabled = false;
    }
   

    void Update () {
        
        if (move == true)
        {
            thrown = true;
            dissablecollider2d.enabled = true;
            rbody2.bodyType = RigidbodyType2D.Dynamic;
        }
        if(holdingGun == true)
        {
            rbody2.bodyType = RigidbodyType2D.Kinematic;
            gunarea.enabled = true;
            sp.enabled = false;
        }
        if (holdingGun == false)
        {
            
            sp.enabled = true;
        }
       if(thrown == true)
        {
            countdowntimer += Time.deltaTime;
            if (countdowntimer > maxscountdowntime)
            {
                thrown = false;

            }
            if (thrown == false)
            {
                countdowntimer = 0;
                Player1 = false;
                Player2 = false;
                Player3 = false;
                Player4 = false;
            }
        }
       if(touchedplayer == true)
        {
            print("touchedplayer");
            countdowntimer1 += Time.deltaTime;
            if(countdowntimer1 > maxscountdowntime1)
            {
                move = false;
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if(collision.tag == "Player1")
        {
            movement = GameObject.FindGameObjectWithTag("Player1").GetComponent<Movment>();
            
            
        }
        if (collision.tag == "Player2")
        {
           movement = GameObject.FindGameObjectWithTag("Player2").GetComponent<Movment>();
      
        }
        if (collision.tag == "Player3")
        {
            movement = GameObject.FindGameObjectWithTag("Player3").GetComponent<Movment>();
     
        }
        if (collision.tag == "Player4")
        {
            movement = GameObject.FindGameObjectWithTag("Player4").GetComponent<Movment>();
        
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        movement = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (thrown == true)
        {
            if (collision.tag == "Player1")
            {
                Player1 = GameObject.FindGameObjectWithTag("GrabbHitbox1").GetComponent<Grabbscript>().droppweapon = true;
                touchedplayer = true;
            }
            if (collision.tag == "Player2")
            {
                Player2 = GameObject.FindGameObjectWithTag("GrabbHitbox2").GetComponent<Grabbscript>().droppweapon = true;
                touchedplayer = true;
            }
            if (collision.tag == "Player3")
            {
                Player3 = GameObject.FindGameObjectWithTag("GrabbHitbox3").GetComponent<Grabbscript>().droppweapon = true;
                touchedplayer = true;
            }
            if (collision.tag == "Player4")
            {
                Player4 = GameObject.FindGameObjectWithTag("GrabbHitbox4").GetComponent<Grabbscript>().droppweapon = true;
                touchedplayer = true;
            }
        }
   
    }
 


}

