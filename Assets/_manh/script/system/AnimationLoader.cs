using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

[Serializable]
struct AnimationHolder
{
    public string state;
    public string[] animations;
}

public class AnimationLoader : MonoBehaviour
{
    [SerializeField] AnimationHolder[] holders;

    public string[] GetAnimation(string state)
    {
        string[] animation = { };

        foreach (var holder in holders)
        {
            if (holder.state == state)
            {
                animation = holder.animations;
                break;
            }
        }

        if(animation.Count() == 0)
        {
            Debug.LogError(animation + "not found in state " + state, this);
        }

        return animation;
    }
}
