using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armor : MonoBehaviour
{

    Rigidbody2D rb;
    float dirX, moveSpeed = 5f;
    public Collider2D armorcol;
    int healthPoints = 1, armorPoints = 1;

    [SerializeField]
    GameObject bulletproofVest = null;

    //[SerializeField]
    //Image healthpoints = null, armor = null;

    bool bulletproofVestIsOn = false;


    // Use this for initialization
    void Start()
    {
        armorcol.enabled = false;
        bulletproofVest.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
       // armor.fillAmount = 0f;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("BulletproofVest"))
        {
            bulletproofVest.SetActive(true);
            bulletproofVestIsOn = true;
           // healthpoints.fillAmount = 1f;
           // armor.fillAmount = 1f;

           // healthPoints = 1;
            armorPoints = 1;
            armorcol.enabled = true;
            //healthPoints = 1;
            //armorPoints = 1;

            Destroy(col.gameObject);
        }

            if (col.tag == "Bullet")
            {
               Destroy(col.gameObject);
            }


    }
}