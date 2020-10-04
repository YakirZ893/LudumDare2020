using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    
    public Transform holdtrans;
    public bool isholding;
    void Start()
    {
        isholding = false;
        
    }
    private void OnTriggerStay(Collider other)
    {
        GameObject go = other.gameObject;

        if (other.gameObject.tag == "CanBeGrabbed" && Input.GetButtonDown("Fire1"))
        {
            go.transform.parent = this.transform;
            isholding = true;
            go.transform.position = holdtrans.position;
            go.GetComponent<Rigidbody>().isKinematic = true;
        }

        if (Input.GetButtonDown("Fire2") && isholding && other.gameObject.tag == "CanBeGrabbed")
        {
           
            go.transform.parent = null;
            go.GetComponent<Rigidbody>().isKinematic = false;
            

        }
            


    }
  
}
