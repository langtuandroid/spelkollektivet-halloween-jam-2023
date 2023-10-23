using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float velocity => agent.velocity.normalized.magnitude;
    private EnemyController _enemyController;
    [SerializeField] private LayerMask _groundLayerMask;
    [SerializeField] private LayerMask _playerLayerMask;
    [HideInInspector]public NavMeshAgent agent;

    [HideInInspector] public Vector3 walkPoint;
    [HideInInspector] public bool walkPointSet;
    public float walkPointRange;
    private float _timeRemaining;
    private bool _timerWorking;
 
    private void Awake()
    {
        _enemyController = GetComponent<EnemyController>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = _enemyController.transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            _timerWorking = true;
        }

    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(_enemyController.transform.position.x + randomX, _enemyController.transform.position.y, _enemyController.transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -_enemyController.transform.up, 2f, _groundLayerMask))
            walkPointSet = true;
    }

    private void Update()
    {
        WaitAtWaypoint();
        //Debug.Log(agent.velocity.normalized.magnitude);
    }

    private void WaitAtWaypoint()
    {
        if (_timeRemaining > 0 && _timerWorking)
        {
            _timeRemaining -= Time.deltaTime;
        }
        if (_timeRemaining <= 0)
        {
            walkPointSet = false;
            _timerWorking = false;
            _timeRemaining = Random.Range(2, 7);
        }
    }

    public void ChaseTarget(Transform target)
    {
        agent.SetDestination(target.position);
    }

    public void StopMoving()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
    }

    public void StartMoving()
    {
        agent.isStopped = false;
    }
}
