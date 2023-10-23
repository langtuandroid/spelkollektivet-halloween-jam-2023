using Archon.SwissArmyLib.Automata;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_MeleeAttack : FsmState<EnemyController>
{
    private float _currentTime;

    public override void Begin()
    {
        base.Begin();
        Context.currentState = CurrentState.MeleeAttack;
        Context.enemyAnimationHandler.PlayMeleeAttack();
        _currentTime = Context.timeBetweenAttacks;
    }

    public override void Reason()
    {
        base.Reason();

    }

    public override void Act(float deltaTime)
    {
        base.Act(deltaTime);
        _currentTime -= deltaTime;
        if( _currentTime < 0)
        {
            Machine.ChangeState<State_Idle>();
        }
    }

    public override void End()
    {
        base.End();
    }
}
