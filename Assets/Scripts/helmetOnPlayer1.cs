using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helmetOnPlayer1 : MonoBehaviour {

    public Cat1 helmet;
    public GameObject hellmet;
    public bool helmHit;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            print("Helmetishit");
            helmet.bulletproofHelmetIsOn = false;
            helmHit = true;
        }
        else
        {
            helmHit = false;
        }
    }
}
