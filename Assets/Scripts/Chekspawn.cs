using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chekspawn : MonoBehaviour
{
    public RandomWeaponSpawner Ran;

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "grabbable")
        {
            Ran.spawned = true;
        }
        else
        {
            Ran.spawned = false;
        }
    }
}
