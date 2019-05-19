using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable_trash : MonoBehaviour
{
    public int Health = 4;
    int currentHP;
    public Animator anim;
    public Transform instantepoint;
    public GameObject destroyeffect;
    
   public void DamageTaken (int Damage)
    {
        //Debug.Log("Hit");
        //Health -= Damage;
        //if(Health <= 0)
        //{
        //   die();
        //}
    
    }

    void die()
    {

        Debug.Log("WOW");
        currentHP = Health;
        Destroy(gameObject);
    }

    void Update()
    {
        if(Health == 3)
        {
            anim.SetBool("3", false);
            anim.SetBool("2", false);
            anim.SetBool("1", true);
        }
        if (Health == 2)
        {
            anim.SetBool("3", false);
            anim.SetBool("2", true);
            anim.SetBool("1", false);
        }
        if (Health == 1)
        {
            anim.SetBool("3", true);
            anim.SetBool("2", false);
            anim.SetBool("1", false);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet" && Health == 1)
        {
            print("propdestroyed");
            Instantiate(destroyeffect, instantepoint.position, instantepoint.rotation);
            die();
        }
        if(collision.tag == "Bullet")
        {
            Health--;
        }
    }
}
