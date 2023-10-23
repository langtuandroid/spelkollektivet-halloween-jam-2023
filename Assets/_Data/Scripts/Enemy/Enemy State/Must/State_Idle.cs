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
        Context.enemyMeshRenderer.material = Context.enemyIdleMaterial;
        
    }

    public override void Reason()
    {
        base.Reason();
        Context.enemyMovement.Patroling();
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
