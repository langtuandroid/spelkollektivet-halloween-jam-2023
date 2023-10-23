using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationEventHandler : MonoBehaviour
{

    private PlayerController _playerController;
    private EnemyController _enemyController;
    [SerializeField] private int _damageAmount = 5;

    private void Awake()
    {
        _enemyController = GetComponent<EnemyController>();
    }

    private void MeleeAttackEvent()
    {
        if(_enemyController.CheckDistance() <= _enemyController.meleeAttackRange + 0.5f)
        {
            _playerController.TakeDamage(_damageAmount);
            Debug.Log("Took 5 Damage");
        }
    }

    public void Initialize(PlayerController player)
    {
        _playerController = player;
    }
}
