using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Control : MonoBehaviour
{
    public GameManager GameManager;
    public float Speed = 5f;
    public float JumpForce = 100f;

    private bool _isGrounded;
    private Rigidbody _rb;
    private byte _countCheckGround;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rb.AddForce(movement * Speed);
        if (transform.position.y < -18f) GameManager.CheckGameOver();
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0 && _countCheckGround>0)
        {
            _rb.AddForce(Vector3.up * JumpForce);
        }
    }
    //check on ground
    void OnCollisionEnter (Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground")) _countCheckGround++;
        } 
    //check out ground
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) _countCheckGround--;
    }
//check coin and finish
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Coin":
                GameManager.IncrementalScore();
                break;
            case "Finish":
                GameManager.Finish();
                break;
        }

    }

//check ground
        // void IsGroundedUpate(Collision collision, bool value)
        // {
        //     if (collision.gameObject.CompareTag(("Ground")))
        //     {
        //         _isGrounded = value;
        //     }
        // }
    }

