using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class AnimationPlayerSequence : BaseSequence
{
    AnimationPlayer animationPlayer;

    private void Awake()
    {
        animationPlayer = transform.FindSibling<AnimationPlayer>();
    }

    protected override IEnumerator GetSequenceImp()
    {
        animationPlayer.PlayAnimation();
        yield return null;
    }
}
