using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogSequence : BaseSequence
{
    [SerializeField] string logMsg = "hello world";
    protected override IEnumerator GetSequenceImp()
    {
        Debug.Log(logMsg, this);
        yield return null;
    }
}
