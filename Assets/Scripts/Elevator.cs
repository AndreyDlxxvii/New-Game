using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private bool _isPlayerOnElevator;
    private void FixedUpdate()
    {
        MoveElevator();
    }

    private void MoveElevator()
    {
        if (_isPlayerOnElevator)
        {
            transform.Translate(Vector3.left * 0.02f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        CheckPlayerOnElevator(other);
    }

    private void CheckPlayerOnElevator(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
            _isPlayerOnElevator = true;
        }
        else if (!collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
        
    }
}
