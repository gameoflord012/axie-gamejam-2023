using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Range(0f, 1f)]
    [SerializeField] float normalizedTime = 0f;
    [SerializeField] GameObject[] spawnObjects;
    [SerializeField] float randomOffset = 3;

    public float NormalizedTime { get => normalizedTime; }

    public void SpawnAll()
    {
        foreach(var spawn in spawnObjects)
        {
            var rand = new Vector2(Random.Range(-randomOffset, randomOffset), Random.Range(-randomOffset, randomOffset));
            Instantiate(spawn, transform.position + (Vector3)rand, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, randomOffset);
    }
}
