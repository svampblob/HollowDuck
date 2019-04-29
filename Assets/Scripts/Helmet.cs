using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helmet : MonoBehaviour
{

    public bool IsHit;
    Rigidbody2D rb;
    float dirX, moveSpeed = 5f;
    public Collider2D helnmetcollider2D;
    int healthPoints = 1, armorPoints = 1;

    [SerializeField]
    GameObject bulletproofHelmet = null;

    //[SerializeField]
    //Image healthpoints = null, armor = null;

    bool bulletproofHelmetIsOn = false;


    // Use this for initialization
    void Start()
    {
        bulletproofHelmet.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        helnmetcollider2D.enabled = false;
        //healthpoints.fillAmount = 1f;
        //armor.fillAmount = 0f;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("BulletproofHelmet"))
        {
            bulletproofHelmet.SetActive(true);
            bulletproofHelmetIsOn = true;
            //healthpoints.fillAmount = 1f;
            //armor.fillAmount = 1f;

            //healthPoints = 1;
            armorPoints = 1;

            //healthPoints = 1;
            //armorPoints = 1;
            helnmetcollider2D.enabled = true;
            Destroy(col.gameObject);
        }

        if (col.tag == "Bullet")
        {
            Destroy(col.gameObject);
        }
    }
               
                
               

}