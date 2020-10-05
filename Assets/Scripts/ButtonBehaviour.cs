﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ButtonBehaviour : MonoBehaviour
{  
    public Animator anim;
  
    public bool isbuttonclicked;
    public bool isbuttonclickedcannon;



    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag =="Recording")
        anim.SetBool("ButtonPressed", true);
        GameObject.FindObjectOfType<AudioManager>().Play("Button");
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

 
