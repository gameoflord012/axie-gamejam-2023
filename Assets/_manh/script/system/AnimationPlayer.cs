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

    [SerializeField] [ReadOnly] int currentAnimationIndex;
    [SerializeField] [ReadOnly] bool stopPlayingAnimation = false;
    string[] currentAnimations;

    private void Awake()
    {
        if(skeleton == null)
        {
            skeleton = transform.root.GetComponentInChildren<SkeletonAnimation>();
        }

        animationState = skeleton.AnimationState;
        animationLoader = transform.FindSibling<AnimationLoader>();
    }

    public void PlayAnimation()
    {
        currentAnimations = animationLoader.GetAnimation(stateName);
        currentAnimationIndex = 0;
        stopPlayingAnimation = false;
        animationState.ClearTracks();

        animationState.Complete += HandleAnimationComplete;
        PlayNextAnimation();
    }

    void PlayNextAnimation()
    {
        if(currentAnimationIndex >= currentAnimations.Length)
        {
            if(doRepeat)
            {
                currentAnimationIndex = 0;
            }
            else
            {
                return;
            }
        }

        if(!stopPlayingAnimation)
        {
            animationState.AddAnimation(0, currentAnimations[currentAnimationIndex], false, 0);
        }
    }

    private void HandleAnimationComplete(TrackEntry track)
    {
        currentAnimationIndex++;
        PlayNextAnimation();
    }

    public void StopAnimation()
    {
        animationState.ClearTracks();
        stopPlayingAnimation = true;
    }
}
