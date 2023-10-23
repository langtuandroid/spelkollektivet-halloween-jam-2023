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
    }

    public override void Reason()
    {
        base.Reason();
        Context.enemyMovement.agent.SetDestination(Context.player.transform.position);
        
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
