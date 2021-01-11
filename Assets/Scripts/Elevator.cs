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
        if (_isPlayerOnElevator && transform.position.x > -5)
        {
            transform.Translate(Vector3.left * 0.02f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        CheckPlayerOnElevator(other);
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = null;
        }
    }

    private void CheckPlayerOnElevator(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        collision.gameObject.transform.SetParent(transform);
        _isPlayerOnElevator = true;
    }
}
