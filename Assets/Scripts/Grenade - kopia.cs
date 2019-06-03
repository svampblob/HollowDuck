using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float explosion_delay = 5f;
    public float explosion_Rate = 1f;
    public float explosion_max_size = 10f;
    public float explosion_speed = 10f;
    public float current_Radius = 0f;
    bool exploded = false;
    int damage = 5;
    CircleCollider2D explosion_radius;

    // Start is called before the first frame update
    void Start()
    {
        explosion_radius = gameObject.GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {

            explosion_delay -= Time.deltaTime;
            if (explosion_delay < 0)
            {
                exploded = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (exploded == true)
        {
           
            if (current_Radius < explosion_max_size)
            {
                current_Radius += explosion_Rate;

            }
            else
            {
                Object.Destroy(this.gameObject.transform.parent.gameObject);
            }
            explosion_radius.radius = current_Radius;

        }

    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        //if (exploded == true)
        //{
        //    if (collider2D.gameObject.rigidbody2D != null)
        //    {
        //        Vector2 target = collider2D.gameObject.transform.position;
        //        Vector2 grenade= gameObject.transform.position;

        //        Vector2 direction = 100f * (target - Grenade);
        //        collider2D.gameObject.rigidbody2D.Addforce(new Vector2(direction.x / 2, direction.y * 10f));

        //    }
        //}




    }

}
