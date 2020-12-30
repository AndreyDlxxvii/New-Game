using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLands : MonoBehaviour
{
    private float _speed = 0.02f;
    private Vector3 _vector3;

    private void Start()
    {
        _vector3 = new Vector3(0, 0, -1);
    }
    void FixedUpdate()
    {
        transform.Translate(_vector3.normalized*_speed);
    }
    
    void OnCollisionEnter(Collision coll)
    {
        coll.transform.parent = transform;
    }

    void OnCollisionExit(Collision coll)
    {
        coll.transform.parent = null;
    }
}
