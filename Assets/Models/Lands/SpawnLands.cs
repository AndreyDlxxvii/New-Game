using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SpawnLands : MonoBehaviour
{
    public GameObject[] prefabs;
    private List<GameObject> _poolLands = new List<GameObject>();
    private float _minSpawnDelay = 5f;
    private float _maxSPawnDelay = 6f;
    void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            var memberLandsPrefabPool = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
            memberLandsPrefabPool.SetActive(false);
            _poolLands.Add(memberLandsPrefabPool);
        }
        Spawn();
        
    }
    void Spawn()
    {
        for (int i = 0; i < _poolLands.Count; i++)
        {
            if (!_poolLands[i].activeInHierarchy)
            {
                _poolLands[i].transform.position = transform.position;
                _poolLands[i].SetActive(true);
                break;
            }
        }
        Invoke("Spawn", Random.Range(_minSpawnDelay, _maxSPawnDelay));
    }
}
