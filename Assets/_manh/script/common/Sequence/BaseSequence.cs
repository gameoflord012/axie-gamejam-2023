using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BaseSequence : MonoBehaviour
{
    public UnityEvent onSequenceStart;
    public UnityEvent onSequenceStop;

    [Header("Base Sequence")]
    [SerializeField] bool disable = false;
    [SerializeField] float delayBeforePlaying = 0;
    protected virtual IEnumerator GetSequenceImp() { yield break; }

    public IEnumerator PlaySequence()
    {
        if(!disable)
        {
            yield return new WaitForSeconds(delayBeforePlaying);
            onSequenceStart?.Invoke();
            yield return GetSequenceImp();
            onSequenceStop?.Invoke();
        }
    }
}
