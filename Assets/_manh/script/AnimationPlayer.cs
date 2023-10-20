using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] string animationName;

    Spine.AnimationState animationState;

    private void Start()
    {
        animationState = skeleton.AnimationState;
    }

    public void PlayAnimation()
    {
        animationState.SetAnimation(0, animationName, true);
    }

    public void StopAnimation()
    {
        animationState.ClearTracks();
    }
}
