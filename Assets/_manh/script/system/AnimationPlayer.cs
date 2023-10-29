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
    }

    public void PlayAnimation()
    {
        currentAnimationIndex = 0;
        stopPlayingAnimation = false;

        animationState.SetEmptyAnimation(0, 0);

        PlayNextAnimation();
    }

    private void HandleAnimationComplete(TrackEntry track)
    {
        if (track.Animation.Duration == 0) return;
        if (stopPlayingAnimation) return;

        PlayNextAnimation();
    }

    private void PlayNextAnimation()
    {
        if (currentAnimationIndex >= currentAnimations.Length)
        {
            if (doRepeat) currentAnimationIndex = 0;
            else
            {
                StopAnimation();
                return;
            }
        }

        animationState.AddAnimation(0, currentAnimations[currentAnimationIndex], false, 0);
        currentAnimationIndex++;

        animationState.Complete -= HandleAnimationComplete;
        animationState.Complete += HandleAnimationComplete;
    }

    public void StopAnimation()
    {
        stopPlayingAnimation = true;
    }
}
