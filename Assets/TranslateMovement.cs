using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;

    private float gravityValue = -9.81f;
    public bool IsGrounded;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*float moveHorizontal = Input.GetAxis("Horizontal");
        

        Vector3 movement = new Vector3(0.0f, 0.0f, moveHorizontal);

        rb.velocity = (movement * speed);
        */

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }
    }
}
