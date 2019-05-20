using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketexplosion : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D Rb;
    public float TimeToDestroy = 0.8f;
    public bool destroyItem;
    public bool armor;
    public GameObject exposion;
    public MultipleTargetCamera1 Cam;
    public int Player1;
    public int Player2;
    public int Player3;
    public int Player4;
    public AudioSource source;
    void Start()
    {
        Rb.velocity = transform.right * speed;
       Cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MultipleTargetCamera1>();
    }
    void Update()
    {
        if (destroyItem == true)
        {
            Destroy(gameObject);
        }
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
        if (hitInfo.gameObject.GetComponent<armorOnPlayer>())
        {
            Destroy(gameObject);
        }
        if (hitInfo.tag == "Player1")
        {
            Player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player>().health = 0;
            Instantiate(exposion, transform.position, transform.rotation);
        }
        if (hitInfo.tag == "Player2")
        {
            Player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player>().health = 0;
            Instantiate(exposion, transform.position, transform.rotation);
            destroyItem = true;
        }
        if (hitInfo.tag == "Player3")
        {
            Player3 = GameObject.FindGameObjectWithTag("Player3").GetComponent<Player>().health = 0;
            Instantiate(exposion, transform.position, transform.rotation);
            destroyItem = true;
        }
        if (hitInfo.tag == "Player4")
        {
            Player4 = GameObject.FindGameObjectWithTag("Player4").GetComponent<Player>().health = 0;
            Instantiate(exposion, transform.position, transform.rotation);
            destroyItem = true;
        }
        if (hitInfo.tag == "Ground")
        {
            destroyItem = true;
            Instantiate(exposion, transform.position, transform.rotation);
        }
        if (hitInfo.tag == "Armor")
        {
            armor = GameObject.FindGameObjectWithTag("Armor").GetComponent<Armor>().bulletproofVestIsOn = false;
            Instantiate(exposion, transform.position, transform.rotation);
            destroyItem = true;
        }
        if (hitInfo.tag == "Props")
        {
            destroyItem = true;
            Instantiate(exposion, transform.position, transform.rotation);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == ("Ground"))
        {
            Instantiate(exposion, transform.position, transform.rotation);
            Cam.shake(0.2f, 0.4f);
            source.Play();
            destroyItem = true;
        }
    }
}
