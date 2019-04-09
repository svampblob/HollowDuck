using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    public Animator anim;
    public float speed = 20f;
    public Rigidbody2D Rb;
    public int damage = 1;
    public Movment move;
    public float TimeToDestroy = 0.8f;
    public GameObject Player1;

    void Start()
    {
        Rb.velocity = transform.right * speed;
    }
    
    private void OnEnable()
    {
        StartCoroutine(AutoDestroy(TimeToDestroy));
    }

    IEnumerator AutoDestroy(float _time)
    {
        yield return new WaitForSeconds(_time);

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            Destroy(gameObject);
        }

    }
}
