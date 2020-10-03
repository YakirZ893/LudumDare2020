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
    private void OnCollisionEnter(Collision collision)
    {
        //collision.transform.parent = this.transform;
        collision.collider.transform.SetParent(transform);
    }
    private void OnCollisionExit(Collision collision)
    {
        //collision.transform.parent = null;
        collision.collider.transform.SetParent(null);
    }
}
