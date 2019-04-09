using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amoshell : MonoBehaviour
{
    public GameObject Ammodhellprfab;
    public Transform droppoint;
    public bool droppamoshell;
    public int noammoshell = 1;
    void Start()
    {
        transform.rotation = Quaternion.identity;
        transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    void Update()
    {
        if(droppamoshell == true)
        {
            if(noammoshell > 0)
            {
                noammoshell--;
                GameObject newBullet = Instantiate(Ammodhellprfab, droppoint.position, droppoint.rotation);
                RaycastHit2D hitInfo = Physics2D.Raycast(droppoint.position, droppoint.right);
            }
        }
    }
}
