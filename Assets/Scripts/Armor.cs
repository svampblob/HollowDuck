using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armor : MonoBehaviour {
    public armorOnPlayer arm;
    
	public int healthPoints = 5, armorPoints = 5;

	[SerializeField]
	GameObject bulletproofVest = null;

	public bool bulletproofVestIsOn = false;

	void Start () {
		bulletproofVest.SetActive (false);
	}
    void Update()
    {
        if(bulletproofVestIsOn == false)
        {
            bulletproofVest.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals ("BulletproofVest")) {
			bulletproofVest.SetActive (true);
			bulletproofVestIsOn = true;
			healthPoints = 5;
			armorPoints = 5;

            Destroy(col.gameObject);
        }

		if (col.gameObject.GetComponent<Bullet1>() != null) {
			if (bulletproofVestIsOn) {
				armorPoints -= 1;
			} else {
				healthPoints -= 1;
			}
		}

	}


}
