using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{

    Rigidbody2D rb;
    float dirX, moveSpeed = 5f;

    int healthPoints = 5, armorPoints = 5;

    [SerializeField]
    GameObject bulletproofVest = null;

    [SerializeField]
    Image healthBar = null, armorBar = null;

    bool bulletproofVestIsOn = false;


    // Use this for initialization
    void Start()
    {
        bulletproofVest.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        healthBar.fillAmount = 1f;
        armorBar.fillAmount = 0f;
    }

    // Update is called once per frame
    //void Update () {
    //	dirX = Input.GetAxisRaw ("Horizontal") * moveSpeed;
    //}

    //void FixedUpdate()
    //{
    //	rb.velocity = new Vector2 (dirX, rb.velocity.y);
    //}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("BulletproofVest"))
        {
            bulletproofVest.SetActive(true);
            bulletproofVestIsOn = true;
            healthBar.fillAmount = 1f;
            armorBar.fillAmount = 1f;
            healthPoints = 5;
            armorPoints = 5;
            Destroy(col.gameObject);
        }

        if (col.gameObject.GetComponent<Bullet>())
        {
            Destroy(col.gameObject);

            if (bulletproofVestIsOn)
            {
                armorBar.fillAmount -= 0.20f;
                armorPoints -= 1;

                if (armorPoints <= 0)
                {
                    bulletproofVestIsOn = false;
                    bulletproofVest.SetActive(false);
                }

            }
            else
            {
                healthBar.fillAmount -= 0.20f;
                healthPoints -= 1;

                if (healthPoints <= 0)
                    Destroy(gameObject);
            }
        }

    }


}
