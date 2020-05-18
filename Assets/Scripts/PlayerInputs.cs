using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerInputs : MonoBehaviour
{
    int JumpSpeed = 10;
    int Speed = 10;
    Rigidbody rb = null;
    bool isGrounded = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                isGrounded = false;
                rb.velocity += Vector3.up * JumpSpeed;
            }
        }
        float moveDirection = Input.GetAxis("Horizontal");
        if (moveDirection != 0)
        {
            rb.AddForce(new Vector2(Speed * moveDirection, 0), ForceMode.Force);
        }
    }

     
    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
