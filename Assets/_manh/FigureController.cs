using System.Collections;
using System.Collections.Generic;
using Algorithms;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

using Point = System.Drawing.Point;

public class FigureController : MonoBehaviour
{
    SkeletonAnimation animation;
    Spine.AnimationState animationState;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<SkeletonAnimation>();
        animationState = animation.AnimationState;

        animationState.SetAnimation(0, "activity/prepare", true);
    }

    // Update is called once per frame
}
