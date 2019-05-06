using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kills : MonoBehaviour
{
    public int score;

    // Update is called once per frame
    void Update()
    {
        
    }
    void AddToScore()
    {
        score = score + 1;
        
    }
}
