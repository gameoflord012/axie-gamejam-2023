using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelaySequence : BaseSequence
{
    [SerializeField] float delayInSeconds;
    protected override IEnumerator GetSequenceImp()
    {
        yield return new WaitForSeconds(delayInSeconds);
    }
}
