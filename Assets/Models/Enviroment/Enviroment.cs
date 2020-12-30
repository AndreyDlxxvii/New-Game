using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    public GameObject[] enviromentsPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            float j = i;
            Vector3 _vectorLeft3 = new Vector3(-10f, 0f, j*3);
            Vector3 _vector3 = new Vector3(10f, 0f, j*3);
            Instantiate(enviromentsPrefabs[Random.Range(0, enviromentsPrefabs.Length)], _vectorLeft3, Quaternion.identity);
            Instantiate(enviromentsPrefabs[Random.Range(0, enviromentsPrefabs.Length)], _vector3, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
