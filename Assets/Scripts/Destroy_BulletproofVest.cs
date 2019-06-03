using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_BulletproofVest : MonoBehaviour
{
    public bool destroyed;
     void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player1")
        {
            Destroy(gameObject);
            destroyed = true;
        }
        if (collision.tag == "Player2")
        {
            Destroy(gameObject);
            destroyed = true;
        }
        if (collision.tag == "Player3")
        {
            Destroy(gameObject);
            destroyed = true;
        }
        if (collision.tag == "Player4")
        {
            Destroy(gameObject);
            destroyed = true;
        }
    }
}
