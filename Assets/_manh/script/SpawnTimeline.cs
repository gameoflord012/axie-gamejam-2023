using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTimeline : MonoBehaviour
{
    [SerializeField] float timelineDuration = 5f;
    [SerializeField] SpawnPoint[] spawners;

    float timer;

    private void Start()
    {
        timer = 0;
    }

    private void Update()
    {
        
    }
}
