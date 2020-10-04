using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody rb;
    [SerializeField] float jumpfroce; 

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
        if(Input.GetAxis("Horizontal")>0 || Input.GetAxis("Horizontal")<0)
        {
          transform.Translate(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpfroce * Time.fixedDeltaTime);
        }
    }
}
