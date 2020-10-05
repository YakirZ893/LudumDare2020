using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationManager : MonoBehaviour
{
    private Animator anim;
    public PlayerInteraction pl;
    public RigidbodyMovement pm;
    public PlayerJMP PJ;

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
       if(!PJ.isGrounded)
        {
            anim.SetBool("isjumping", true);
        }
        else
        {
            anim.SetBool("isjumping", false);
        }
        
    }
}
