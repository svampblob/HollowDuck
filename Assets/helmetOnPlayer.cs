using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helmetOnPlayer : MonoBehaviour {

    public bool isHit;
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        isHit = true;
    if(isHit == true)
        {
            Destroy(gameObject);
        }
    }



}
