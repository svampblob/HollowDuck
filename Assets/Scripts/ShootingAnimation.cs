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
                if(Gun.NoAmmo == false)
                {
                    if (Gun.shooting == true)
                    {
                        anim.SetBool("IsShooting", true);
                    }

                    if (Gun.shooting == false)
                    {
                        anim.SetBool("IsShooting", false);
                    }
                }
            }
                
        
    }
   
}
