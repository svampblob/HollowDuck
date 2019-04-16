﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armor : MonoBehaviour
{

    Rigidbody2D rb;
    float dirX, moveSpeed = 5f;

    int healthPoints = 1, armorPoints = 1;

    [SerializeField]
    GameObject bulletproofVest = null;

    [SerializeField]
    Image healthpoints = null, armor = null;

    bool bulletproofVestIsOn = false;


    // Use this for initialization
    void Start()
    {
        bulletproofVest.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        healthpoints.fillAmount = 1f;
        armor.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        //dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    void FixedUpdate()
    {
        //rb.velocity = new Vector2(dirX, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("BulletproofVest"))
        {
            bulletproofVest.SetActive(true);
            bulletproofVestIsOn = true;
            healthpoints.fillAmount = 1f;
            armor.fillAmount = 1f;

            healthPoints = 1;
            armorPoints = 1;

            healthPoints = 1;
            armorPoints = 1;

            Destroy(col.gameObject);
        }

            if (col.gameObject.GetComponent<Bullet1>() != null)
            {
                Destroy(col.gameObject);


        //        if (bulletproofVestIsOn)
        //        {
        //            armor.fillAmount -= 1f;


        //            if (bulletproofVestIsOn)
        //            {
        //                armor.fillAmount -= 0.2f;

        //                armorPoints -= 1;

        //                if (armorPoints <= 0)
        //                {
        //                    bulletproofVestIsOn = false;
        //                    bulletproofVest.SetActive(false);
        //                }

        //            }
        //            //else
        //            //{

        //            //    healthpoints.fillAmount -= 1f;

        //            //    healthpoints.fillAmount -= 0.2f;

        //            //    healthPoints -= 1;

        //            //    if (healthPoints <= 0)
        //            //        Destroy(gameObject);
        //            //}
             }

        //    }

    }
    //}
}