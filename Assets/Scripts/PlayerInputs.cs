using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerInputs : MonoBehaviour
{
    public AudioClip JumpSFX = null;
    public AudioClip LandSFX = null;
    public ParticleSystem JumpEffect = null;
    float FallSpeed = 0;
    int JumpSpeed = 15;
    int Speed = 15;
    Rigidbody rb = null;
    bool isGrounded = false;
    bool jumpRequet;
    AudioSource audioSource;

    void Start()
    {
        StartCoroutine(FallDelay());
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (!GameManager.Instance.CanPlay)
        {
            return;
        }
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            jumpRequet = true;
        }
    }
    void FixedUpdate()
    {
        transform.position += Vector3.down * FallSpeed;
        if (!GameManager.Instance.CanPlay)
        {
            return;
        }
        if (jumpRequet)
        {
            Jump();
        }
        float moveDirection = Input.GetAxis("Horizontal");
        if (moveDirection != 0)
        {
            rb.AddForce(new Vector2(Speed * moveDirection, 0), ForceMode.Force);
        }
        if (transform.position.y < -6)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void Jump()
    {
        JumpEffect.Play();
        audioSource.clip = JumpSFX;
        audioSource.Play();
        rb.velocity += Vector3.up * JumpSpeed;
        isGrounded = false;
        jumpRequet = false;
    }

    IEnumerator FallDelay()
    {
        yield return new WaitForSeconds(3);
        FallSpeed = GameManager.Instance.FallSpeed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            audioSource.clip = LandSFX;
            audioSource.Play();
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }
}
