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

    [SerializeField][ReadOnly] bool isRunning = false;
    [SerializeField][ReadOnly] int currentSequenceIndex = 0;

    Coroutine runningCoroutine;

    public void PlayAll()
    {
        if (isRunning) return;
        runningCoroutine = StartCoroutine(PlayRepeatlyCoroutine());
    }

    public void StopAll()
    {
        StopCoroutine(runningCoroutine);
        isRunning = false;
        onSequenceStop?.Invoke();
    }

    IEnumerator PlayRepeatlyCoroutine()
    {
        isRunning = true;

        do
        {
            for(int i = 0; i < sequences.Count(); i++)
            {
                currentSequenceIndex = i;
                yield return sequences[i].PlaySequence();
            }

        } while (playRepeatly);

        isRunning = false;
    }
}
