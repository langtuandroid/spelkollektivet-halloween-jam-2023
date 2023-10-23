using Archon.SwissArmyLib.Automata;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{


    private FiniteStateMachine<EnemyController> _stateMachine;
    // Start is called before the first frame update
    void Start()
    {
        _stateMachine =  new FiniteStateMachine<EnemyController>(this, new State_Idle());
        _stateMachine.RegisterState(new State_MoveToRandomPosition());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
