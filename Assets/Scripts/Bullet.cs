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
          
            Debug.Log("oh no");
        }
    }



    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.tag == "Player1")
        {
            Destroy(gameObject);
            shooter.SendMessage("AddToScore", 5);
        }
        if (hitInfo.tag == "Player2")
        {
            Destroy(gameObject);
            shooter.SendMessage("AddToScore", 5);
        }
        if (hitInfo.tag == "Player3")
        {
            Destroy(gameObject);
            shooter.SendMessage("AddToScore", 5);
        }
        if (hitInfo.tag == "Player4")
        {
            Destroy(gameObject);
            shooter.SendMessage("AddToScore", 5);
        }
    }
    void AddToScore(int points)
    {
        score += points;
    }


}
