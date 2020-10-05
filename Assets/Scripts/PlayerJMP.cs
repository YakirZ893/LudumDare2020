using UnityEngine;
using System.Collections;
using UnityEditor;

[RequireComponent(typeof(Rigidbody))]
public class PlayerJMP : MonoBehaviour
{
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded = true;
    private bool haslanded = false;
    public Transform smoke;
    public GameObject smokePrefab;
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
           GameObject go= Instantiate(smokePrefab, smoke.position, Quaternion.Euler(90,0,0));
            isGrounded = false;
            haslanded = true;

            Destroy(go, 1f);
        
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "CanBeGrabbed")
        {
            isGrounded = true;
            if (haslanded)
            {
                GameObject go = Instantiate(smokePrefab, smoke.position, Quaternion.Euler(90, 0, 0));
                Destroy(go, 1f);
                haslanded = false;
            }
        }
    }
}


