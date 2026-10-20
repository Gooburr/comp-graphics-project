using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coconutspawner : MonoBehaviour
{
    public GameObject coconut;
    public float spawnRange = 15;
    private void Start()
    {
        SpawnCoconut();
        if (coconut == null) Debug.LogError("Please give the coconut spawner a coconut prefab");
    }
    public void SpawnCoconut()
    {
        transform.position = new Vector3(Random.Range(-spawnRange, spawnRange), transform.position.y, Random.Range(-spawnRange, spawnRange));
        Instantiate(coconut,transform);
    }
}
