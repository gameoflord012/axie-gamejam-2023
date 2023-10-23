using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] string animationName;
    [SerializeField] bool doRepeat = true;

    Spine.AnimationState animationState;

    private void Awake()
    {
        if(skeleton == null)
        {
            skeleton = transform.root.GetComponentInChildren<SkeletonAnimation>();
        }

        animationState = skeleton.AnimationState;
    }

    public void PlayAnimation()
    {
        animationState.SetAnimation(0, animationName, doRepeat);
    }

    public void StopAnimation()
    {
        animationState.ClearTracks();
    }
}
