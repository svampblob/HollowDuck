using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderONOF : MonoBehaviour {
    public Collider2D dissablecollider2d;
    public Rigidbody2D rbody2;
    public bool move;
    public Movment movement;
    public SpriteRenderer sp;
    public bool GUNONOF;
    public Collider2D gunarea;
    public Collider2D grabablearea;
    private Grabbscript grab;
    public bool holdingGun;
    public bool playerison;

    void Start()
    {
        dissablecollider2d.enabled = false;
        gunarea.enabled = false;
        
           
    }
    void Update () {

		if(move == true)
        {
            dissablecollider2d.enabled = true;
            rbody2.bodyType = RigidbodyType2D.Dynamic;
        }
        if(move == false)
        {
            dissablecollider2d.enabled = false;
            rbody2.bodyType = RigidbodyType2D.Kinematic;
        }
        if(holdingGun == true)
        {
            grabablearea.enabled = false;
            gunarea.enabled = false;
            sp.enabled = false;
        }
        if (holdingGun == false)
        {
            grabablearea.enabled = true;
            sp.enabled = true;
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
}
