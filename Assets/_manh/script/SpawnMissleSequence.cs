using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMissleSequence : BaseSequence
{
    [SerializeField] MissleSpawner spawner;
    [SerializeField] Attacker attacker;

    private void Start()
    {
        spawner = transform.FindSibling<MissleSpawner>();
        attacker = transform.FindSibling<Attacker>();
    }

    protected override IEnumerator GetSequenceImp()
    {
        spawner.SpawnTo(attacker.GetAttackTarget().transform);
        yield break;
    }
}
