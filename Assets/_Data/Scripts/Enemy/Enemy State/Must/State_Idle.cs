using Archon.SwissArmyLib.Automata;
using Archon.SwissArmyLib.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idle : FsmState<EnemyController>
{
    public override void Begin()
    {
        base.Begin();
        Context.currentState = CurrentState.Idle;
    }

    public override void Reason()
    {
        base.Reason();
        Context.enemyMovement.Patrolling();
        if (Context.isPlayerInFieldOfView && !Context.playerInMeleeAttackRange) Machine.ChangeState<State_Chase>();
    }

    public override void Act(float deltaTime)
    {
        base.Act(deltaTime);
    }

    public override void End()
    {
        base.End();
    }

    
}
