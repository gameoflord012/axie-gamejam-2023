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
    [SerializeField] bool debug;

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

    public MissleNav SpawnTo(Transform followTransform)
    {
        return SpawnMissle(followTransform);
    }

    public void SpawnRange(Transform[] followTransform)
    {
        for (int i = 0; i < Mathf.Min(followTransform.Count(), maxMissleSpawnCount); i++)
        {
            SpawnTo(followTransform[i]);
        }
    }

    private MissleNav SpawnMissle(Transform followTransform)
    {
        var dir = followTransform.transform.position - transform.position;

        bool flip = dir.x < 0;

        var rotation = Quaternion.identity;
            //Quaternion.LookRotation(Vector3.forward, dir) *
            //Quaternion.Euler(0, 0, degreeOffset * (flip ? -1 : 1));

        var missle = Instantiate(
            misslePrefab,
            transform.position, rotation);

        missle.FollowTransform = followTransform;

        missle.onMissleReached.AddListener(onMissleReached.Invoke);

        if (destroyWhenMissleReached)
            missle.onMissleReached.AddListener(missle => Destroy(missle.gameObject));

        return missle;
    }
}
