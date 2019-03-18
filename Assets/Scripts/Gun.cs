using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform FirePoint;
    public GameObject bulletPrefab;
    public int damage = 1;
    public int Maxammo = 1;
    public int currentAmmo;
    private bool NoAmmo = false;
    public bool Shooting;
    public bool IsShooting;
    public Movment move;
    public int Player;

    void Start()
    {
        if (currentAmmo == -1)
            currentAmmo = Maxammo;
        Player = move.Player;
        
    }
    // Update is called once per frame
    void Update()
    {

        if (currentAmmo <= 0)
        {
            //Debug.Log("Out of ammo");
            NoAmmo = true;
        }

        if (IsShooting == true)

            Shoot();

    }

    public void Shoot()
    {


        currentAmmo--;
        GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
       // bullet.GetComponent<Bullet>().firer = gameObject (Player);
        RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position, FirePoint.right);


    }

}
