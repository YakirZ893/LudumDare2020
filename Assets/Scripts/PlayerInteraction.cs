using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    SphereCollider SC;
    void Start()
    {
        SC = GetComponent<SphereCollider>();
    }
    private void OnTriggerStay(Collider other)
    {
        GameObject go = other.gameObject;
        if (other.gameObject.tag == "CanBeGrabbed" && Input.GetKeyDown(KeyCode.E))    
            go.transform.parent = this.transform; 

        if (Input.GetKeyUp(KeyCode.E) && go.transform.IsChildOf(this.transform))
            go.transform.parent = null;   

    }
  
}
