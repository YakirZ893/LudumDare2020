using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    [SerializeField] BoxCollider BC;
    void Start()
    {
        BC = this.GetComponent<BoxCollider>();
        
    }
    private void OnCollisionStay(Collision collision)
    {
        print(collision.gameObject.name);
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Recording")
        collision.collider.transform.SetParent(this.gameObject.transform);
    }
    private void OnCollisionExit(Collision collision)
    {
        //collision.transform.parent = null;
        collision.collider.transform.SetParent(null);
    }
}
