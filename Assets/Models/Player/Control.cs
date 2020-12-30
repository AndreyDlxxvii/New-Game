using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Control : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 100f;

    private bool _isGrounded;
    private Rigidbody _rb;

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
        print(message: moveHorizontal);
        float moveVertical = Input.GetAxis("Vertical");
        print(moveVertical);
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        _rb.AddForce(movement * speed);
    }

    private void Jump()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                _rb.AddForce(Vector3.up * jumpForce);
            }
        }
    }

    void OnCollisionEnter (Collision collision)
        {
            IsGroundedUpate(collision, true);
            // if (collision.gameObject.CompareTag("Ground"))
            // {
            //     gameObject.transform.parent = collision.transform;
            // }
        }

        void OnCollisionExit(Collision collision)
        {
            IsGroundedUpate(collision, false);
            // if (collision.gameObject.CompareTag("Ground"))
            // {
            //     gameObject.transform.parent = null;
            // }
        }

        void IsGroundedUpate(Collision collision, bool value)
        {
            print(collision.gameObject.tag);
            if (collision.gameObject.CompareTag(("Ground")))
            {
                _isGrounded = value;
            }
        }
    }

