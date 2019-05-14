using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat1 : MonoBehaviour {

    public helmetOnPlayer1 helnm;

    public int healthPoints = 5, armorPoints = 5;

	[SerializeField]
	GameObject bulletproofHelmet = null;

	public bool bulletproofHelmetIsOn = false;

	void Start () {
		bulletproofHelmet.SetActive (false);
	}
    void Update()
    {
        if(bulletproofHelmetIsOn == false)
        {
            bulletproofHelmet.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals ("BulletproofHelmet")) {
            
            bulletproofHelmet.SetActive(true);
            bulletproofHelmetIsOn = true;
            healthPoints = 5;
            armorPoints = 5;

            Destroy(col.gameObject);
        }
			
		if (col.gameObject.GetComponent<Bullet1>()) {
			if (bulletproofHelmetIsOn) {
				armorPoints -= 1;
			} else {
				healthPoints -= 1;
			}
		}

	}


}
