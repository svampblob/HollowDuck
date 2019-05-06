using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // public AudioClip expsoundeffect;
    public GameObject bloodeffect;
    public int health = 1;
    public Transform Weaponholder;
    public AudioSource exp;
    public MultipleTargetCamera cam;
    public GUNS gunScript;

    private GameObject enemyPlayer;
    private bool dead;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MultipleTargetCamera>();
    }
    private void Update()
    {
        if (health <= 0)
        {

            Die();
        }
    }

    void Die()
    {
        if (dead == false)
        {
            dead = true;
            Instantiate(bloodeffect, Weaponholder.position, Weaponholder.rotation);
            Destroy(gameObject, 0.4f);
            Camera.main.GetComponent<MultipleTargetCamera>().targets.Remove(transform);


            //lägg till ett till poäng i kill scriptet 
            Kills kill = enemyPlayer.GetComponent<Kills>();
            kill.Invoke("AddToScore", 0f);
            //kill.SendMessage("AddToScore", 1);
        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            health = 0;
            exp.Play();
            cam.shake(0.1f, 0.2f);
            if (collision.gameObject.name == "Fire_Bullet 1(Clone)")
            {
                print("Hej");
                enemyPlayer = GameObject.FindWithTag("Player1");
            }
            if (collision.gameObject.name == "Fire_Bullet 2(Clone)")
            {
                enemyPlayer = GameObject.Find("Player2");
            }
            if (collision.gameObject.name == "Fire_Bullet 3(Clone)")
            {
                enemyPlayer = GameObject.Find("Player3");
            }
            if (collision.gameObject.name == "Fire_Bullet 4(Clone)")
            {
                enemyPlayer = GameObject.Find("Player4");
            }
        }
        if (collision.tag == "Void")
        {
            health = 0;
            exp.Play();
            cam.shake(0.1f, 0.2f);

        }
    }
}
