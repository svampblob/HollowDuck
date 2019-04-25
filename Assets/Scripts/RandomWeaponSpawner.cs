using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWeaponSpawner : MonoBehaviour
{
    // prefab instantiate
    public GameObject Prefab1, Prefab2, Prefab3;
    public bool spawned;
    // spawn rate
    public float SpawnRate = 8f;

    float nextSpwan = 0F;

    //Random value in here 
    int whatToSpwan;


    // Update is called once per frame
    void Update()
    {
        if(spawned == false)
        {
            if (Time.time > nextSpwan)
            {
                whatToSpwan = Random.Range(0, 4);
                Debug.Log(whatToSpwan);

                switch (whatToSpwan)
                {

                    case 1:
                        Instantiate(Prefab1, transform.position, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(Prefab2, transform.position, Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(Prefab3, transform.position, Quaternion.identity);
                        break;
                }

                nextSpwan = Time.time + SpawnRate;
            }

        }

    }
}
