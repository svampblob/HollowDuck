using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armorOnPlayer : MonoBehaviour
{
    public Armor arm;
    public GameObject armor;
    public bool ArmorHit;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet1>())
        {
            print("Armorishit");
            arm.bulletproofVestIsOn = false;
            ArmorHit = true;
        }
        else
        {
            ArmorHit = false;
        }
    }
}