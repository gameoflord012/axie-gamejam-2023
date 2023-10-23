using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseSequence : MonoBehaviour
{
    public UnityEvent onSequenceStart;
    public UnityEvent onSequenceStop;

    [SerializeField] bool disable = false;
    protected virtual IEnumerator GetSequenceImp() { yield break; }

    public IEnumerator PlaySequence()
    {
        if(!disable)
        {
            onSequenceStart?.Invoke();
            yield return GetSequenceImp();
            onSequenceStop?.Invoke();
        }
    }
}
