using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public GameObject Prefab;
    // Start is called before the first frame update
    void Start()    
    {
        var position = transform.TransformPoint(0f, 1f, 0f);
        Debug.Log(position);
        var obj = Instantiate(Prefab, position, Quaternion.identity) as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
