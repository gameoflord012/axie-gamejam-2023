using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Rider.Unity.Editor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class MissleSpawner : MonoBehaviour
{
    public UnityEvent<MissleNav> onMissleReached;

    [SerializeField] MissleNav misslePrefab;
    [SerializeField] int maxMissleSpawnCount = 1;
    [SerializeField] bool destroyWhenMissleReached;

    //[SerializeField] float degreeOffset = 0;
    [SerializeField] bool spawnAtDestination = false;
    [SerializeField] bool debug;

    private Attacker figureAttacker;

    private void Awake()
    {
        figureAttacker = transform.FindSibling<Attacker>();
    }

    private void Update()
    {
        if(debug && Input.GetKeyDown(KeyCode.Space))
        {
            var newGO = new GameObject();
            newGO.transform.position = Vector2.zero;
            newGO.transform.parent = transform;

            SpawnTo(newGO.transform);
        }
    }

    private MissleNav SpawnTo(Transform followTransform)
    {
        return SpawnMissle(followTransform);
    }

    private MissleNav SpawnTo(Health health)
    {
        var missle = SpawnMissle(health.transform);
        Attacker attacker = missle.GetComponentInChildren<Attacker>();
        attacker.WhiteList.Add(health);

        attacker.Damage += figureAttacker.Damage;

        return missle;
    }

    public void SpawnRange(Health[] healths)
    {
        for (int i = 0; i < Mathf.Min(healths.Count(), maxMissleSpawnCount); i++)
        {
            SpawnTo(healths[i]);
        }
    }

    private void SpawnRange(Transform[] followTransform)
    {
        for (int i = 0; i < Mathf.Min(followTransform.Count(), maxMissleSpawnCount); i++)
        {
            SpawnTo(followTransform[i]);
        }
    }

    private MissleNav SpawnMissle(Transform followTransform)
    {
        var missle = Instantiate(
            misslePrefab,
            spawnAtDestination ? followTransform.position : transform.position, 
            Quaternion.identity);

        missle.FollowTransform = followTransform;

        missle.onMissleReached.AddListener(onMissleReached.Invoke);

        if (destroyWhenMissleReached)
            missle.onMissleReached.AddListener(missle => Destroy(missle.gameObject));

        return missle;
    }
}
