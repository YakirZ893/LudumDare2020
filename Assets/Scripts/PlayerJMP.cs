using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJMP : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded = true;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

   

    void FixedUpdate()
    {
        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            
            
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "CanBeGrabbed")
        {
            isGrounded = true;

        }
    }
}


