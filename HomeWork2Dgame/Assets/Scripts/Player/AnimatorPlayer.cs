using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string IsRunning = "IsRunning";
    private const string IsJumping = "IsJumping";

    public void Run()
    {
        _animator.SetBool(IsRunning, true);
    }

    public void EnableIdle()
    {
        _animator.SetBool(IsRunning, false);
        _animator.SetBool(IsJumping, false);
    }

    public void Jumping()
    {
        _animator.SetBool(IsJumping, true);
        _animator.SetBool(IsRunning, false);
    }
}
