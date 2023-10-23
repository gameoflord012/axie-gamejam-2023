using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SequencePlayer : MonoBehaviour
{
    [SerializeField] BaseSequence[] sequences;
    [SerializeField] bool playRepeatly = false;

    Coroutine runningCoroutine;

    public void PlayAll()
    {
        runningCoroutine = StartCoroutine(PlayRepeatlyCoroutine());
    }

    public void StopAll()
    {
        StopCoroutine(runningCoroutine);
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
