using Archon.SwissArmyLib.Automata;
using Archon.SwissArmyLib.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Chase : FsmState<EnemyController>
{
    public override void Begin()
    {
        base.Begin();
        Context.currentState = CurrentState.Chase;
        Context.enemyMovement.StartMoving();
    }

    public override void Reason()
    {
        base.Reason();
        Context.enemyMovement.ChaseTarget(Context.player.transform);
        if(Context.CheckDistance() <= Context.meleeAttackRange)
        {
            Machine.ChangeState<State_MeleeAttack>();
        }
        if (Context.CheckDistance() >= Context.maxChasingRange)
        {
            Machine.ChangeState<State_Idle>();
        }
    }

    public override void Act(float deltaTime)
    {
        base.Act(deltaTime);

    }

    public override void End()
    {
        base.End();
        Context.enemyMovement.StopMoving();
    }
}
