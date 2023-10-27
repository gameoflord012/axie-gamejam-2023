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

    [SerializeField] bool isRunning = false;

    Coroutine runningCoroutine;

    public void PlayAll()
    {
        if (isRunning) return;
        runningCoroutine = StartCoroutine(PlayRepeatlyCoroutine());
    }

    public void StopAll()
    {
        StopCoroutine(runningCoroutine);
        onSequenceStop?.Invoke();
    }

    IEnumerator PlayRepeatlyCoroutine()
    {
        isRunning = true;

        do
        {
            foreach (var sequence in sequences)
            {
                yield return sequence.PlaySequence();
            }

        } while (playRepeatly);

        isRunning = false;
    }
}
