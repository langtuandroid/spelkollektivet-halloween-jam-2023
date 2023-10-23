using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PastController : MonoBehaviour
{
    [SerializeField] private PastAnimationHandler _animationHandler;
    [SerializeField] private PastMovement _movement;
    [SerializeField] private PastShooting _shooting;
    [SerializeField] private PastSoundHandler _sound;
    [SerializeField] private HealthBody _health;


    private void Awake()
    {
        SetupComponent();
        InitialiseCalls();
    }
    private void InitialiseCalls()
    {
        _health.Initialise();
        _animationHandler.Initialise();
    }

    private void SetupComponent()
    {
        _animationHandler = GetComponentInChildren<PastAnimationHandler>();
        _movement = GetComponent<PastMovement>();
        _shooting = GetComponent<PastShooting>();
        _sound = GetComponent<PastSoundHandler>();
        _health = GetComponent<HealthBody>();
    }

    private void FixedUpdate()
    {
        _movement.RunTimeLoop();
    }

    public void SetPositionInTime(List<PositionInTime> positionInTimes)
    {
        _movement.SetPositionInTime(positionInTimes);
    }

    private void OnEnable()
    {
        _health.OnHeal += WhenHeal;
        _health.OnDeath += WhenDeath;
        _health.OnDamage += WhenDamage;
    }

    private void OnDisable()
    {
        _health.OnHeal -= WhenHeal;
        _health.OnDeath -= WhenDeath;
        _health.OnDamage -= WhenDamage;
    }

    private void WhenHeal()
    {
        _sound.PlayHealSound();
    }

    private void WhenDamage()
    {
        _sound.PlayDamageSound();
    }

    private void WhenDeath()
    {
        _sound.PlayDeathSound();
    }
}
