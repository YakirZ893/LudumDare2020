using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    public bool iswalking;


    



   
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        

        if (Horizontal > 0)
        {
            Vector3 movement = new Vector3(0, 0, 1f);
            transform.rotation = Quaternion.LookRotation(movement);
        }

        if (Horizontal < 0)
        {
            Vector3 movement = new Vector3(0, 0, -1f);
            transform.rotation = Quaternion.LookRotation(movement);
        }



        if (Horizontal != 0)
            iswalking = true;

        else
        {
            iswalking = false;


        }

        rb.velocity = new Vector3(0f, rb.velocity.y, Horizontal * speed);
        
        
            

       
    }
}



    







