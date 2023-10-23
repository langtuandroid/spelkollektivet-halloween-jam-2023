using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour, IDamageable
{
    [SerializeField] private int _damageScale = 1;
    private HealthBody _health;

    public int DamageScale { get => _damageScale; set => _damageScale = value; }

    public void SetHealth(HealthBody health)
    {
        _health = health;
    }

    public void TakeDamage(int damageAmount)
    {
        _health.TakeDamage(damageAmount * _damageScale);
    }
}