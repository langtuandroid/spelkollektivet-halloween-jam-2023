using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastAnimationHandler : AnimationHandler
{
    private int _movementParameter;


    public override void Initialise()
    {
        base.Initialise();
        _movementParameter = Animator.StringToHash("Movement");
    }

    public void SetMovement(float amount)
    {
        _animator.SetFloat(_movementParameter, amount);
        Debug.Log(amount);
    }
}
