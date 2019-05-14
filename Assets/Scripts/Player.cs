using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject playerobject;
    public GameObject bloodeffect;
    public Collider2D charactercollider;
    public int health = 1;
    public Transform Weaponholder;
    public AudioSource exp;
    public AudioSource sheildbarke;
    public MultipleTargetCamera cam;
    public Armor armor;
    public Collider2D playercollider;
    public bool die;
    
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MultipleTargetCamera>();

    }
    void Update()
    {
        if (health <= 0)
        {
           
            Die();
        }
       if(armor.bulletproofVestIsOn == true)
       {
            playercollider.enabled = false;
       }
        if(armor.bulletproofVestIsOn == false)
        {
            playercollider.enabled = true;
        }
     
    }
    
    void Die()
    {
     
        Instantiate(bloodeffect, Weaponholder.position, Weaponholder.rotation);
        Destroy(playerobject, 0.4f);
        Camera.main.GetComponent<MultipleTargetCamera>().targets.Remove(transform);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Void")
        {
            health = 0;
            exp.Play();
            cam.shake(0.1f, 0.2f);
        }
        if(collision.tag == "Bullet")
        {
            if(health <= 0)
            {
                exp.Play();
                cam.shake(0.1f, 0.2f);
            }
        }
        if(collision.tag == "Bullet")
        {
            if(armor.bulletproofVestIsOn == false && health > 0)
            {
                sheildbarke.Play();
            }
        }
    }
}
