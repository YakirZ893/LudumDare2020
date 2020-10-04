using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonProjectileScript : MonoBehaviour
{
    public Transform target; 
   
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Target").transform;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime);



        Destroy(this.gameObject, 1.4f);
        
    }
}
