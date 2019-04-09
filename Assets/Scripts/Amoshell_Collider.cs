using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amoshell_Collider : MonoBehaviour
{
    public Collider2D dissablecollider2d;
    public Rigidbody2D rbody2;
    public float power = 0.125f;

    // Start is called before the first frame update
    void Start()
    {
        rbody2.velocity = new Vector3(transform.localPosition.y, 0.0125f * power);
        dissablecollider2d.enabled = true;
        rbody2.bodyType = RigidbodyType2D.Dynamic;
    }
}
