using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   // public AudioClip expsoundeffect;
    public GameObject bloodeffect;
    public int health = 1;
    public Transform Weaponholder;
    public AudioSource exp;
    public MultipleTargetCamera cam;
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MultipleTargetCamera>();
    }
    private void Update()
    {
        if (health <= 0)
        {
          
            Die();
        }
    }
    
    void Die()
    {
        Instantiate(bloodeffect, Weaponholder.position, Weaponholder.rotation);
   
        Destroy(gameObject, 0.4f);
        Camera.main.GetComponent<MultipleTargetCamera>().targets.Remove(transform);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            health = 0;
            exp.Play();
            cam.shake(0.1f, 0.2f);
        }
        if(collision.tag == "Void")
        {
            health = 0;
            exp.Play();
            cam.shake(0.1f, 0.2f);

        }
    }
}
