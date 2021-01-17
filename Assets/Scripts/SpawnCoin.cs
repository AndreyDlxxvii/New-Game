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
//spawn coin as child platform
    private void SpawnGoldCoinOnScene()
    {
        foreach (Transform child in transform)
        {
            var position = child.transform.TransformPoint(0f,1f,0f);
            var obj = Instantiate(prefab);
            obj.transform.position = position;
            obj.transform.SetParent(child);
            //obj.transform.position = position;
            //obj.transform.position = new Vector3(position.x , position.y+1f, position.z);
        }
    }

}
