using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

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
        spawner.SpawnRange(attacker.GetAttackTargets().Select(target => target.transform).ToArray());
        yield break;
    }
}
