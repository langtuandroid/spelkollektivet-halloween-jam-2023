using Archon.SwissArmyLib.Automata;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour
{
    private FiniteStateMachine<EnemyController> _stateMachine;

    [Header("Field of View")]
    [SerializeField] private float _fieldOfViewRadius;
    [Range(0, 360)]
    [SerializeField] private float _fieldOfViewAngle;
    
    public LayerMask fieldOfViewTargetMask;
    public LayerMask fieldOfViewObstructionMask;

    [Header("Attacking")]
    public float timeBetweenAttacks;
    public float meleeAttackRange;

    [Header("Debugging")]
    [SerializeField] TMP_Text _curentStateText;

    [HideInInspector] public bool isPlayerInFieldOfView;
    [HideInInspector] public CurrentState currentState;
    [HideInInspector] public MeshRenderer enemyMeshRenderer;
    [HideInInspector] public GameObject player;
    [HideInInspector] public EnemyMovement enemyMovement;
    [HideInInspector] public bool playerInMeleeAttackRange;
    [HideInInspector] public bool alreadyAttacked;
    [HideInInspector] public EnemyAnimationHandler animationHandler;

    private void Awake()
    {
        SetupComponents();
    }
    private void Start()
    {
        StartCoroutine(FOVRoutine());
        RegisterAllStates();
    }

    private void Update()
    {
        StateLogic();
        ChangeAnimation();
        DebugText();
    }

    private void SetupComponents()
    {
        enemyMeshRenderer = GetComponentInChildren<MeshRenderer>();
        player = GameObject.FindWithTag("Player");
        enemyMovement = GetComponent<EnemyMovement>();
        animationHandler = GetComponentInChildren<EnemyAnimationHandler>();
    }

    private void DebugText()
    {
        _curentStateText.text = currentState.ToString();
    }

    private void StateLogic()
    {
        _stateMachine.Update(Time.deltaTime);
        if (!isPlayerInFieldOfView && !playerInMeleeAttackRange) _stateMachine.ChangeState<State_Idle>();
        if (isPlayerInFieldOfView && !playerInMeleeAttackRange) _stateMachine.ChangeState<State_Chase>();
        if (isPlayerInFieldOfView && playerInMeleeAttackRange) _stateMachine.ChangeState<State_MeleeAttack>();
    }

    private void RegisterAllStates()
    {
        _stateMachine = new FiniteStateMachine<EnemyController>(this, new State_Idle());
        _stateMachine.RegisterState(new State_MoveToRandomPosition());
        _stateMachine.RegisterState(new State_Death());
        _stateMachine.RegisterState(new State_Chase());
        _stateMachine.RegisterState(new State_MeleeAttack());
        _stateMachine.RegisterState(new State_ShootAttack());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, _fieldOfViewRadius, fieldOfViewTargetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < _fieldOfViewAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, fieldOfViewObstructionMask))
                    isPlayerInFieldOfView = true;
                else
                    isPlayerInFieldOfView = false;
            }
            else
                isPlayerInFieldOfView = false;
        }
        else if (isPlayerInFieldOfView)
        {
            isPlayerInFieldOfView = false;
        }
    }

    private void ChangeAnimation()
    {
        animationHandler.SetMovement(enemyMovement.velocity);
    }
}

public enum CurrentState
{
    Idle,
    Patrolling,
    Chase,
    MeleeAttack,
    RangeAttack,
    Death
}