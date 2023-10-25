using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnMissleSequence : BaseSequence
{
    public UnityEvent onMissleReached;

    [SerializeField] MissleSpawner spawner;
    [SerializeField] Attacker attacker;

    private void Start()
    {
        spawner = transform.FindSibling<MissleSpawner>();
        attacker = transform.FindSibling<Attacker>();
    }

    protected override IEnumerator GetSequenceImp()
    {
        var missle = spawner.SpawnTo(attacker.GetAttackTarget().transform);
        missle.onMissleReached?.AddListener(onMissleReached.Invoke);

        yield break;
    }
}
