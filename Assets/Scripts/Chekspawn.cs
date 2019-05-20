using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chekspawn : MonoBehaviour
{
    public RandomWeaponSpawner Ran;

    void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "grabbable")
        {
            Ran.spawned = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Ran.spawned = false; 
    }
}
