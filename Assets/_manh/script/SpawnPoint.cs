using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] float normalizedTime = 0f;
    [SerializeField] GameObject[] spawnObjects;
    [SerializeField] float randomRad = 2f;

    private void Start()
    {
        SpawnAll();
    }

    void SpawnAll()
    {
        foreach(var spawn in spawnObjects)
        {

            Instantiate(spawn, transform.position, Quaternion.identity);
        }
    }
}
