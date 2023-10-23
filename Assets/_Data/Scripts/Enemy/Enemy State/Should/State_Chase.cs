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
        if(Vector3.Distance(Context.transform.position, Context.player.transform.position) <= Context.meleeAttackRange)
        {
            Machine.ChangeState<State_MeleeAttack>();
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
