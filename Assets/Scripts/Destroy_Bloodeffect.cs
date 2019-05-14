using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bloodeffect : MonoBehaviour
{
    public AudioSource exp;

  
    void Update()
    {
        Destroy(gameObject, 0.4f);
    }

}
