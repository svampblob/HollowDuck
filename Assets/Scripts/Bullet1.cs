using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D Rb;
    public float TimeToDestroy = 0.8f;
    public bool destroyItem;
    public bool armor;
    public int Player1;
    public int Player2;
    public int Player3;
    public int Player4;
    void Start()
    {
        Rb.velocity = transform.right * speed;
    }
    void Update()
    {
        if(destroyItem == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        StartCoroutine(AutoDestroy(TimeToDestroy));
    }

    IEnumerator AutoDestroy(float _time)
    {
        yield return new WaitForSeconds(_time);

        Destroy(gameObject);
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.GetComponent<armorOnPlayer>())
        {
            Destroy(gameObject);
        }
       if(hitInfo.tag == "Player1")
       {
            Player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player>().health = 0;
       }
       if (hitInfo.tag == "Player2")
        {
            Player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player>().health = 0;
            destroyItem = true;
        }
       if (hitInfo.tag == "Player3")
        {
            Player3 = GameObject.FindGameObjectWithTag("Player3").GetComponent<Player>().health = 0;
            destroyItem = true;
        }
       if (hitInfo.tag == "Player4")
        {
            Player4 = GameObject.FindGameObjectWithTag("Player4").GetComponent<Player>().health = 0;
            destroyItem = true;
        }
       if(hitInfo.tag == "Ground")
        {
            destroyItem = true;
        }
       if(hitInfo.tag == "Armor")
       {
            armor = GameObject.FindGameObjectWithTag("Armor").GetComponent<Armor>().bulletproofVestIsOn = false;
            destroyItem = true;
       }
     
    }
}
