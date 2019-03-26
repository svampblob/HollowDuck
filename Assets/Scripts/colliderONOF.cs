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
    void Start()
    {
        dissablecollider2d.enabled = false;
        
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
        if(movement.holdingGun == true)
        {
            
            sp.enabled = false;
        }
        if (movement.holdingGun == false)
        {
            sp.enabled = true;
        }
    }
}
