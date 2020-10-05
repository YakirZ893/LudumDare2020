using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ButtonBehaviour : MonoBehaviour
{  
    public Animator anim;
  
    public bool isbuttonclicked;
    public bool isbuttonclickedcannon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Recording")
        {
            GameObject.FindObjectOfType<AudioManager>().Play("Button");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag =="Recording")
        anim.SetBool("ButtonPressed", true);
        isbuttonclicked = true;
        isbuttonclickedcannon = true;
        
    }

      private void OnTriggerExit(Collider other)
        {
            anim.SetBool("ButtonPressed", false);
            isbuttonclicked = false;
        isbuttonclickedcannon = false;
            
        }

}

 
