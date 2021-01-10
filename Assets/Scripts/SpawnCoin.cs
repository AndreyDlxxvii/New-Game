using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        SpawnGoldCoinOnScene();
    }

    private void SpawnGoldCoinOnScene()
    {
        foreach (Transform child in transform)
        {
            var position = child.transform.position;
            var obj = Instantiate(prefab);
            obj.transform.position = new Vector3(position.x , position.y+1f, position.z);
        }
    }

}
