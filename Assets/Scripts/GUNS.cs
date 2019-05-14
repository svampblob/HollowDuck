using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUNS : MonoBehaviour
{


    public Transform FirePoint;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public int damage = 1;
    //public Movment move;
    public bool shooting;
    public bool NoAmmo;
    public int Ammo;
    public int minus_Ammo = 1;
    public Amoshell ammo;
    public ShootingAnimation shoot;
    public AudioSource source;
    public bool changedirectionleft;
    public bool changedirectionright;
    public Transform shooter;

    private GameObject weaponHolder;
    private GameObject player;
    private int playerNumber;



    void Update()
    {
        if (shooting == true)
        {
            weaponHolder = gameObject.transform.parent.gameObject;
            player = weaponHolder.transform.parent.gameObject;
            if (player.name == "Player1")
                playerNumber = 1;
            if (player.name == "Player2")
                playerNumber = 2;
            if (player.name == "Player3")
                playerNumber = 3;
            if (player.name == "Player4")
                playerNumber = 4;
        }


        if (changedirectionleft == true)
        {
            transform.rotation = Quaternion.identity;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (changedirectionright == true)
        {
            transform.rotation = Quaternion.identity;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (shooting == true)
        {
            Shoot();

        }
        if (shooting == false)
        {
            shoot.shooting = false;
            ammo.droppamoshell = false;
        }
        if (Ammo <= 0)
        {
            NoAmmo = true;
        }
    }

    void Shoot()
    {

        if (NoAmmo == false)
        {
            shoot.shooting = true;
            source.Play();

            Ammo--;
            if (playerNumber == 1)
            {
                Instantiate(bullet1, FirePoint.position, FirePoint.rotation);
            }
            if (playerNumber == 2)
            {
                Instantiate(bullet2, FirePoint.position, FirePoint.rotation);
            }
            if (playerNumber == 3)
            {
                Instantiate(bullet3, FirePoint.position, FirePoint.rotation);
            }
            if (playerNumber == 4)
            {
                Instantiate(bullet4, FirePoint.position, FirePoint.rotation);
            }
            RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position, FirePoint.right);
            ammo.droppamoshell = true;

        }

    }
    //(bulletPrefab, FirePoint.position, FirePoint.rotation);
}
