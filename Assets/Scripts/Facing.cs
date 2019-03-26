using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Facing : MonoBehaviour
{
    
    public Animator animator;
    public string ShootingKey;
    public int Player;
    public Movment move;

    private void Start()
    {
        ShootingKey = move.ShootingKey;
        Player = move.Player;
    }
    void Update()
    {
      if(Input.GetButtonDown(ShootingKey + Player))
        {

        }
    }
}
