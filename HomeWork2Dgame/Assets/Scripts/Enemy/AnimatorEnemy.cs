using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimatorEnemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private const string IsAttack = "IsAttack";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            PlayAttack();
        }
    }

    private void PlayAttack()
    {
        _animator.SetBool(IsAttack, true);        
    }
}
