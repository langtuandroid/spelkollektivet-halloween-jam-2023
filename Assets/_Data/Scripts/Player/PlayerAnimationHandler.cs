using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : AnimationHandler
{
    private int _movementParameter;

    public override void Initialise()
    {
        base.Initialise();
        _movementParameter = Animator.StringToHash("Movement");
    }
}
