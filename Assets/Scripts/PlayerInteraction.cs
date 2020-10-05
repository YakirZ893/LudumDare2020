using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    
    public Transform holdtrans;
    public bool isholding;
    public bool IsAnimating;
    public float timeToWait = 0;

    private GameObject Socket;

    void Start()
    {
        isholding = false;
        
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "CanBeGrabbed" && Input.GetButtonDown("Fire1"))
        {
            Socket = other.gameObject;
            Socket.GetComponent<Rigidbody>().isKinematic = true;
            Socket.transform.parent = this.transform;
            //isholding = true;
            IsAnimating = true;
            StartCoroutine("wait");
            
        }

        if (Input.GetButton("Fire2") && isholding && other.gameObject.tag == "CanBeGrabbed")
        {
            IsAnimating = false;
            isholding = false;
            Socket.transform.parent = null;
            Socket.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    IEnumerator wait()
    {      
        yield return new WaitForSeconds(timeToWait);
        isholding = true;
    }


    private void Update()
    {
        if (isholding)
        {
            Socket.transform.position = holdtrans.position;  
        }
    }

}
