using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] string stateName;
    [SerializeField] bool doRepeat = true;

    Spine.AnimationState animationState;
    AnimationLoader animationLoader;

    private void Awake()
    {
        if(skeleton == null)
        {
            skeleton = transform.root.GetComponentInChildren<SkeletonAnimation>();
        }

        animationState = skeleton.AnimationState;
    }

    private void Start()
    {
        animationLoader = transform.FindSibling<AnimationLoader>();
    }

    public void PlayAnimation()
    {
        animationState.SetAnimation(0, animationLoader.GetAnimation(stateName), doRepeat);
    }

    public void StopAnimation()
    {
        animationState.ClearTracks();
    }
}
