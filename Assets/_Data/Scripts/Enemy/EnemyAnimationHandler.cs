using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationHandler : AnimationHandler
{
    private int _movementParameter;

    public override void Initialise()
    {
        base.Initialise();
        _movementParameter = Animator.StringToHash("EnemyMovement");
    }

    public void SetMovement(float amount)
    {
        _animator.SetFloat("EnemyMovement", amount);
    }

    public void PlayMeleeAttack()
    {
        _animator.CrossFade("MeleeAttack", 0.2f);
    }
}
