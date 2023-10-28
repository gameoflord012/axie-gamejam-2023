using Spine;
using Spine.Unity;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField] SkeletonAnimation skeleton;
    [SerializeField] string stateName;
    [SerializeField] bool doRepeat = true;
    [SerializeField] bool stopPlayingAnimation = false;

    Spine.AnimationState animationState;
    AnimationLoader animationLoader;

    [SerializeField] [ReadOnly] int currentAnimationIndex;
    string[] currentAnimations;

    private void Awake()
    {
        if(skeleton == null)
        {
            skeleton = transform.root.GetComponentInChildren<SkeletonAnimation>();
        }

        animationState = skeleton.AnimationState;
        animationLoader = transform.FindSibling<AnimationLoader>();

        currentAnimations = animationLoader.GetAnimation(stateName);
        stopPlayingAnimation = true;

        animationState.Complete += HandleAnimationComplete;
    }

    public void PlayAnimation()
    {

        currentAnimationIndex = 0;
        stopPlayingAnimation = false;

        animationState.SetEmptyAnimation(0, 0);
        PlayCurrentAnimation();
    }

    private void HandleAnimationComplete(TrackEntry track)
    {
        if (stopPlayingAnimation) return;

        currentAnimationIndex++;

        if(currentAnimationIndex >= currentAnimations.Length)
        {
            if (doRepeat) currentAnimationIndex = 0;
            else
            {
                StopAnimation();
                return;
            }
        }

        PlayCurrentAnimation();
    }

    private void PlayCurrentAnimation()
    {
        animationState.AddAnimation(0, currentAnimations[currentAnimationIndex], false, 0);
    }

    public void StopAnimation()
    {
        animationState.SetEmptyAnimation(0, 0);
        stopPlayingAnimation = true;
    }
}
