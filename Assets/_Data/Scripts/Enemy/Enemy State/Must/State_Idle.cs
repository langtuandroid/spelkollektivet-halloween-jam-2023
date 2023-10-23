using Archon.SwissArmyLib.Automata;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Idle : FsmState<EnemyController>
{
    public override void Begin()
    {
        base.Begin();
    }

    public override void Reason()
    {
        base.Reason();
        

        Machine.ChangeState<State_MoveToRandomPosition>();
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
