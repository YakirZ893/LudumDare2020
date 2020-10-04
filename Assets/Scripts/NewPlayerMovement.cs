using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float fallingSpeed = 1.0f;
    public bool groundedPlayer;
    public bool iswalking;
    public bool isjumping;

    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;
    private CharacterController controller;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            isjumping = false;

            
        }

        Vector3 move = new Vector3(0, 0, Input.GetAxis("Horizontal"));

        //controller.Move(move * Time.deltaTime * playerSpeed);



        if(Input.GetAxis("Horizontal") > 0)
            transform.Translate(move * playerSpeed * Time.deltaTime );

        if(Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(-move * playerSpeed * Time.deltaTime);
        }

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            iswalking = true;
        }
        else
        {
            iswalking = false;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            isjumping = true;
        }

        playerVelocity.y += gravityValue * Time.deltaTime * fallingSpeed;
        controller.Move(playerVelocity * Time.deltaTime);

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "CanBeGrabbed")
        {
            this.transform.parent = hit.transform;
        }
        if (hit.gameObject.tag == "Ground")
            this.transform.parent = null;

    }
}