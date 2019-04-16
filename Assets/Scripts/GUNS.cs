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
    public Amoshell ammo;
    public ShootingAnimation shoot;
    public AudioSource source;
    
    void Update()
    {
        
       if(shooting == true)
       {
            Shoot();
            shoot.shooting = true;
            
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
            source.Play();

            Ammo --;
            GameObject newBullet = Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
                RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position, FirePoint.right);
                ammo.droppamoshell = true;
                
            if (hitInfo)
                {
                    Player player = hitInfo.transform.GetComponent<Player>();
                    if (player != null)
                    {
                        player.TakeDamage(damage);
                    }

                }
            

        }
       
    }
   
}
