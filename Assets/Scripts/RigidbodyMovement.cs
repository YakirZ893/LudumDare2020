using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;

    
    public bool IsGrounded;


   
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float Horizontal = Input.GetAxis("Horizontal");
       
        rb.velocity = new Vector3(0f, rb.velocity.y, Horizontal * speed);
    }
}



    







