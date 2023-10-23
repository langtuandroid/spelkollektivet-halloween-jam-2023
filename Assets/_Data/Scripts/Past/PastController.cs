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
    [SerializeField] private RagDoll _ragDoll;

    private bool _isAlive;

    private void Awake()
    {
        SetupComponent();
        InitialiseCalls();
    }
    private void InitialiseCalls()
    {
        _isAlive = true;
        _health.Initialise();
        _animationHandler.Initialise();
        _movement.Initialise(_animationHandler);
        _ragDoll.Initialise();
    }

    private void SetupComponent()
    {
        _animationHandler = GetComponentInChildren<PastAnimationHandler>();
        _ragDoll = GetComponentInChildren<RagDoll>();
        _movement = GetComponent<PastMovement>();
        _shooting = GetComponent<PastShooting>();
        _sound = GetComponent<PastSoundHandler>();
        _health = GetComponent<HealthBody>();
    }

    private void FixedUpdate()
    {
        if (_isAlive)
        {
            _movement.RunTimeLoop();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            _health.TakeDamage(500);
        }
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
        _isAlive = false;
        _ragDoll.ActivateRagdoll(true);
    }
}
