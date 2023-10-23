using Archon.SwissArmyLib.Automata;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_ShootAttack : FsmState<EnemyController>
{
    public override void Begin()
    {
        base.Begin();
        Context.enemyMeshRenderer.material = Context.enemyAttackMaterial;
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
