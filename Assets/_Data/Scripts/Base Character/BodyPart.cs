using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour, IDamageable
{
    private HealthBody _health;

    public void SetHealth(HealthBody health)
    {
        _health = health;
    }

    public void TakeDamage(int damageAmount)
    {
        _health.TakeDamage(damageAmount);
    }
}