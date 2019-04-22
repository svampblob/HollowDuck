using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUNS : MonoBehaviour {


    public Transform FirePoint;
    public GameObject bulletPrefab;
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

    void Update()
    {
       if(changedirectionleft == true)
       {
            transform.rotation = Quaternion.identity;
            transform.rotation = Quaternion.Euler(0, 180, 0);
       }
       if(changedirectionright == true)
       {
            transform.rotation = Quaternion.identity;
            transform.rotation = Quaternion.Euler(0, 0, 0);
       }
       if(shooting == true)
       {
            Shoot();
           
       }
       if(shooting == false)
       {
            shoot.shooting = false;
            ammo.droppamoshell = false;
       }
       if(Ammo <= 0)
       {
            NoAmmo = true;
       }
    }
    
    void Shoot()
    {
       
       if(NoAmmo == false)
       {
            shoot.shooting = true;
            source.Play();

            Ammo--;
            GameObject newBullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
                RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position, FirePoint.right);
                ammo.droppamoshell = true;
        
        }
       
    }
   
}
