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

    public void EndPickup()
    {
        anim.SetBool("PickedUp", false);

    }


    void Update()
    {
        print(anim.GetBool("PickedUp"));
        
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





        if (pl.isholding)
        {

        anim.SetBool("PickedUp", true);
              
        }

        if (!pl.isholding && anim.GetBool("PickedUp") == false && Input.GetButtonDown("Fire2"))
        {
            anim.SetBool("PutDown", true);
        }






    }

    
    
}
