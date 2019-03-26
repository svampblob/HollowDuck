using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAnimation : MonoBehaviour
{
    public Grabbscript grab;
    public Movment move;
    public int Player;
    public bool grabbed;
    public bool isshooting;
    public string stringformat;
    public Animator anim;

    void Update()
    {
        Animation();

        
    }

    void Animation()
    {
        if(move.holdingGun == true)
        {
            if (move)
            {
                if (Input.GetButtonDown(move.ShootingKey + move.Player))
                {


                    anim.SetBool("IsShooting", true);

                }

                if (Input.GetButtonUp(move.ShootingKey + move.Player))
                {


                    anim.SetBool("IsShooting", false);

                }
            }
       

        }
    }
}
