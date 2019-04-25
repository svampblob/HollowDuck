﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chekspawn : MonoBehaviour
{
    public RandomWeaponSpawner Ran;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "grabbable")
        {
            Ran.spawned = true;
        }
        else
        {
            Ran.spawned = false;
        }
    }
}
