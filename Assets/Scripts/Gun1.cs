using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun1 : MonoBehaviour {

	[SerializeField]
	GameObject bullet;
		
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1"))
			Instantiate (bullet, bullet.transform.position, bullet.transform.rotation);
	}
}
