using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armorOnPlayer : MonoBehaviour {
    public bool IsHit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsHit = true;
        if(IsHit == true)
        {
            Destroy(gameObject);
        }
    }
}
