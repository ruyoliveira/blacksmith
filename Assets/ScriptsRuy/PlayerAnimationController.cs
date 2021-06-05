using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        DisableAllAnimations(_anim);

    }

    // Update is called once per frame
    public void Play(string animParam)
    {
        _anim.SetBool(animParam,true);
    }
    public void Stop(string animParam)
    {
        _anim.SetBool(animParam, false);
    }
    public void SetAnimation(string animParam, bool value)
    {
        _anim.SetBool(animParam, value);
    }
    public void DisableOtherAnimations(Animator anim, string animation)
    {
        foreach (AnimatorControllerParameter param in anim.parameters)
        {
            if (param.name != animation)
            {
                anim.SetBool(param.name, false);
            }
        }
    }
    public void DisableAllAnimations(Animator anim)
    {
        foreach (AnimatorControllerParameter param in anim.parameters)
        {
            anim.SetBool(param.name, false);
        }
    }
}
