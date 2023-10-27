using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class SequencePlayer : MonoBehaviour
{
    public UnityEvent onSequenceStop;

    [SerializeField] BaseSequence[] sequences;
    [SerializeField] bool playRepeatly = false;

    Coroutine runningCoroutine;

    public void PlayAll()
    {
        runningCoroutine = StartCoroutine(PlayRepeatlyCoroutine());
    }

    public void StopAll()
    {
        StopAllCoroutines();
        onSequenceStop?.Invoke();
    }

    IEnumerator PlayRepeatlyCoroutine()
    {
        do
        {
            foreach (var sequence in sequences)
            {
                yield return sequence.PlaySequence();
            }

        } while (playRepeatly);
    }
}
