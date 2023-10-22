using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class AnimationPlayerSequence : BaseSequence
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] string animationName;
    [SerializeField] bool doRepeat = true;

    Spine.AnimationState animationState;

    private void Awake()
    {
        if (skeleton == null)
            skeleton = GetComponentInParent<SkeletonAnimation>();

        animationState = skeleton.AnimationState;
    }

    protected override IEnumerator GetSequenceImp()
    {
        animationState.SetAnimation(0, animationName, doRepeat);
        yield return null;
    }
}
