using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Firer;
    public float speed = 20f;
    public Rigidbody2D Rb;
    public int damage = 1;
    public Movment move;
    public string fire;
    public int Player;
    public Transform shooter;
    public int score = 1;


    // Use this for initialization
    void Start()
    {

        Rb.velocity = transform.right * speed;

        if (Input.GetAxisRaw(move.movekey + move.Player) < 0)
        {
            speed = -speed;
        }
        if (Input.GetAxisRaw(move.movekey + move.Player) > 0)
        {
            speed = 20f;
        }
        GetComponent<Bullet>().shooter = transform;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          //  Debug.Log("[0]", score);
            Debug.Log("oh no");
        }
    }



    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {

            player.TakeDamage(damage);
            Destroy(gameObject);
            shooter.SendMessage("AddToScore", 5);
        }
    }
    void AddToScore(int points)
    {
        score += points;
    }


}
