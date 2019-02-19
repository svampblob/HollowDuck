using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject bulletPrefab;
    public int damage = 1;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            Shoot();
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
        RaycastHit2D hitInfo = Physics2D.Raycast(FirePoint.position, FirePoint.right);

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
