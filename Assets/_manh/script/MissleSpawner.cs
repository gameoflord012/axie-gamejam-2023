using System.Collections;
using System.Collections.Generic;
using JetBrains.Rider.Unity.Editor;
using UnityEngine;
using UnityEngine.Rendering;

public class MissleSpawner : MonoBehaviour
{
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

    public void SpawnTo(Transform followTransform)
    {
        var dir = followTransform.transform.position - transform.position;

        var rotation =
            Quaternion.LookRotation(Vector3.forward, dir) *
            Quaternion.Euler(0, 0, degreeOffset);

        var missle = Instantiate(
            misslePrefab, 
            transform.position, rotation);

        missle.FollowTransform = followTransform;
    }
}
