using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAnimation : MonoBehaviour
{
    
    public Animator anim;
    public bool right;
    public bool left;
    public GUNS Gun;
    public bool shooting;

    void Update()
    {
        Animation();
        
    }
    
    void Animation()
    {
            if (Gun)
            {

                    if (shooting == true)
                    {
                        anim.SetBool("IsShooting", true);
                    }

                    if (shooting == false)
                    {
                        anim.SetBool("IsShooting", false);
                    }
                
            }
                
        
    }
   
}
