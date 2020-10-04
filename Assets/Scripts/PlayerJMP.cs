using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJMP : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

   

    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            //rb.velocity.y = 10.0f;

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
        
        }
            isGrounded = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;

        }
    }
}


