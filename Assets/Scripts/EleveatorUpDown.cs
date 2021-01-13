using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleveatorUpDown : MonoBehaviour
{
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
    }
}
