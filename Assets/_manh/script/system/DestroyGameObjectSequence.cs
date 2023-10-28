using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObjectSequence : BaseSequence
{
    [SerializeField] GameObject gameObjectToDestroy;
    protected override IEnumerator GetSequenceImp()
    {
        if (gameObjectToDestroy)
            Destroy(gameObjectToDestroy);

        yield break;
    }
}
