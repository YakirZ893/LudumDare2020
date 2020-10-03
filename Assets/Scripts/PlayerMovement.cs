using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float jumpforce;
    [SerializeField] Rigidbody rb;
   [SerializeField] bool isgrounded;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        isgrounded = true;
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if (x > 0 || x < 0)
            rb.AddForce(-Vector3.right * x * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            rb.AddForce(Vector3.up * jumpforce * Time.deltaTime, ForceMode.Impulse);
            isgrounded = false;    
        }
        resetJumps();
    }
    private void resetJumps()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position,-Vector3.up, out hit, 1f))
            if (hit.transform.gameObject.tag == ("Ground"))
                isgrounded = true;
        Debug.DrawRay(transform.position, transform.TransformDirection(-Vector3.up) * hit.distance, Color.yellow);
    }
}
