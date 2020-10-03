using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    SphereCollider SC;
    public Transform holdtrans;
    private bool isholding;
    void Start()
    {
        isholding = false;
        SC = GetComponent<SphereCollider>();
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
        if (Input.GetButtonDown("Fire2") && isholding)
        {
            go.transform.parent = null;
            go.GetComponent<Rigidbody>().isKinematic = false;
            

        }
            


    }
  
}
