using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int health = 5;



    // public GameObject deathEffect;

   
   
    public void TakeDamage(int damage, Transform firer)
    {
        health -= damage;
        if (health <= 0)
        {


            Die();
            firer.GetComponent<KillCounter>().playerscore++;
      





        }
    }
   



public void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);



    }



}
