using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helmet1 : MonoBehaviour
{

    public bool IsHit;
    Rigidbody2D rb;
    float dirX, moveSpeed = 5f;

    int healthPoints = 1, armorPoints = 1;

    [SerializeField]
    GameObject bulletproofHelmet = null;

    [SerializeField]
    Image healthpoints = null, armor = null;

    bool bulletproofHelmetIsOn = false;


    // Use this for initialization
    void Start()
    {
        bulletproofHelmet.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        healthpoints.fillAmount = 1f;
        armor.fillAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("BulletproofHelmet"))
        {
            bulletproofHelmet.SetActive(true);
            bulletproofHelmetIsOn = true;
            healthpoints.fillAmount = 1f;
            armor.fillAmount = 1f;

            healthPoints = 1;
            armorPoints = 1;

            healthPoints = 1;
            armorPoints = 1;

            //Destroy(col.gameObject);
        }

        if (col.gameObject.GetComponent<Bullet1>())
        {
            Destroy(col.gameObject);


            //    if (bulletproofHelmetIsOn)
            //    {
            //        armor.fillAmount -= 1f;


            //        if (bulletproofHelmetIsOn)
            //        {
            //            armor.fillAmount -= 0.2f;

            //            armorPoints -= 1;

            //            if (armorPoints <= 0)
            //            {
            //                bulletproofHelmetIsOn = false;
            //                bulletproofHelmet.SetActive(false);
            //            }
        }
    }
               
                
                
                //else
                //{

                //    healthpoints.fillAmount -= 1f;

                //    healthpoints.fillAmount -= 0.2f;

                //    healthPoints -= 1;

                //    if (healthPoints <= 0)
                //        Destroy(gameObject);
                //}
            //}


}