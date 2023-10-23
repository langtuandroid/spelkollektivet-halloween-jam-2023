using Archon.SwissArmyLib.Automata;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Field of View")]
    [SerializeField] private float _fieldOfViewRadius;
    [Range(0, 360)]
    [SerializeField] private float _fieldOfViewAngle;
    
    public LayerMask fieldOfViewTargetMask;
    public LayerMask fieldOfViewObstructionMask;

    [HideInInspector] public bool isPlayerInFieldOfView;

    [HideInInspector] public MeshRenderer enemyMeshRenderer;

    [HideInInspector] public GameObject player;
    [HideInInspector] public EnemyMovement enemyMovement;

    //Attacking
    public float timeBetweenAttacks;
    [HideInInspector] public bool alreadyAttacked;

    //States
    public float meleeAttackRange;
    [HideInInspector] public bool playerInMeleeAttackRange;


    [Header("State Materials")]
    public Material enemyIdleMaterial;
    public Material enemyChaseMaterial;
    public Material enemyAttackMaterial;
    public Material enemyDeathMaterial;

    private FiniteStateMachine<EnemyController> _stateMachine;

    private void Awake()
    {
        enemyMeshRenderer = GetComponentInChildren<MeshRenderer>();
        player = GameObject.FindWithTag("Player"); 
        enemyMovement = GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        _stateMachine.Update(Time.deltaTime);
        if (!isPlayerInFieldOfView && !playerInMeleeAttackRange) _stateMachine.ChangeState<State_Idle>();
        if (isPlayerInFieldOfView && !playerInMeleeAttackRange) _stateMachine.ChangeState<State_Chase>();
        if (isPlayerInFieldOfView && playerInMeleeAttackRange) _stateMachine.ChangeState<State_MeleeAttack>();
    }

    void Start()
    {
        StartCoroutine(FOVRoutine());
        RegisterAllStates();
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

    
}
