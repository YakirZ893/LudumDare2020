using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationManager : MonoBehaviour
{
    private Animator anim;
    public PlayerInteraction pl;
    public NewPlayerMovement pm;

    void Start()
    {
        anim = GetComponent<Animator>(); 
    }  
    void Update()
    {
       if(pm.iswalking)
        {
            anim.SetBool("iswalking", true);
        }
       else
        {
            anim.SetBool("iswalking",false);
        }    
       if(pm.isjumping)
        {
            anim.SetBool("isjumping", true);
        }
        else
        {
            anim.SetBool("isjumping", false);
        }
        
    }
}
