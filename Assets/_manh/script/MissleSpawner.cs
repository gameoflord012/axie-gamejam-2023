using System.Collections;
using System.Collections.Generic;
using JetBrains.Rider.Unity.Editor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class MissleSpawner : MonoBehaviour
{
    public UnityEvent onMissleReached;

    [SerializeField] MissleNav misslePrefab;
    [SerializeField] float degreeOffset = 0;

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
        var dir = followTransform.transform.position - transform.position;

        bool flip = dir.x < 0;

        var rotation =
            Quaternion.LookRotation(Vector3.forward, dir) *
            Quaternion.Euler(0, 0, degreeOffset * (flip ? -1 : 1));

        var missle = Instantiate(
            misslePrefab, 
            transform.position, rotation);

        missle.FollowTransform = followTransform;
        missle.onMissleReached.AddListener(onMissleReached.Invoke);

        return missle;
    }
}
