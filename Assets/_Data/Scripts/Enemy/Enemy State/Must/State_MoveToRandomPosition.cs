using Archon.SwissArmyLib.Automata;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_MoveToRandomPosition : FsmState<EnemyController>
{
    public override void Begin()
    {
        base.Begin();
        Context.currentState = CurrentState.Patrolling;
    }

    public override void Reason()
    {
        base.Reason();

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
