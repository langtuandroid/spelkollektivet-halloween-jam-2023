using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastAnimationHandler : AnimationHandler
{
    private int _movementParameter;
    private int _isOnGroundParameter;


    public override void Initialise()
    {
        base.Initialise();
        _movementParameter = Animator.StringToHash("Movement");
        _isOnGroundParameter = Animator.StringToHash("IsOnGround");
    }

    public void SetMovement(float amount)
    {
        _animator.SetFloat(_movementParameter, amount);
    }

    public void SetIsOnGround(bool value)
    {
        _animator.SetBool(_isOnGroundParameter, value);
    }
}
