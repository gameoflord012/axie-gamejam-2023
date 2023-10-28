using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnTimeline : MonoBehaviour
{
    float timelineDuration = 5f;
    [SerializeField] SpawnPoint[] spawners;

    [SerializeField][ReadOnly] float timer;

    List<int> spawnedIndex = new();

    private void Start()
    {
        BeginTimerline();
    }

    private void BeginTimerline()
    {
        timelineDuration = transform.FindSibling<UI_MainGameProvider>().GetMaxTime();
        timer = 0;
        spawnedIndex.Clear();
    }

    private void Update()
    {
        for(int i = 0; i < spawners.Count(); i++)            
        {
            if (spawnedIndex.Contains(i))
                continue;

            var spawn = spawners[i];

            if (spawn.NormalizedTime < timer / timelineDuration)
            {
                spawn.SpawnAll();
                spawnedIndex.Add(i);
            }
        }

        timer += Time.deltaTime;
    }
}
