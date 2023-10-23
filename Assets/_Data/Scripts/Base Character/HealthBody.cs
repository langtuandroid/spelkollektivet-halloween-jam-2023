using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBody : MonoBehaviour, IDamageable,IHealable
{
    [SerializeField] private int _startHealth;

    private int _currentHealth;
    private int _maxHealth;

    private BodyPart[] _bodyParts;

    public Action OnDeath;
    public Action OnDamage;
    public Action OnHeal;

    public void Initialise()
    {
        _bodyParts = GetComponentsInChildren<BodyPart>();

        foreach (BodyPart bodyPart in _bodyParts)
        {
            bodyPart.SetHealth(this);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        if (_currentHealth < 0)
        {
            OnDeath?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
        }
    }

    private void Awake()
    {
        _maxHealth = _startHealth;
        _currentHealth = _maxHealth;
    }

    public void Heal(int healAmount)
    {
        _currentHealth += healAmount;

        if(_currentHealth < _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

        OnHeal?.Invoke();
    }
}