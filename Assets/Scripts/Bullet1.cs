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

    void Start()
    {
        Rb.velocity = transform.right * speed;
    }
    private void Update()
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
    private void OnCollisionEnter2D(Collision col)
    {
        if(col.gameObject.name == "Ground")
        {
            Destroy(col.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
       if(hitInfo.tag == "Player1")
       {
            print("death");
            destroyItem = true;
       }
       if (hitInfo.tag == "Player2")
        {
            print("death");
            destroyItem = true;
        }
       if (hitInfo.tag == "Player3")
        {
            print("death");
            destroyItem = true;
        }
       if (hitInfo.tag == "Player4")
        {
            print("death");
            destroyItem = true;
        }
       if(hitInfo.tag == "Ground")
        {
            destroyItem = true;
        }
    }
}
