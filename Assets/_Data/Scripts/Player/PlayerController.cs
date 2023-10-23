using EasyCharacterMovement.Examples.Cinemachine.FirstPersonExample;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CMFirstPersonCharacter _firstPersonCharacter;
    [SerializeField] private PlayerRecord _playerRecord;
    [SerializeField] private PlayerMovement _movement;
    [SerializeField] private PlayerSoundHandler _sound;
    [SerializeField] private PlayerAnimationHandler _animationHandler;
    [SerializeField] private HealthBody _health;

    private void Awake()
    {
        SetupComponent();
        InitialiseCalls();
    }

    private void InitialiseCalls()
    {
        _playerRecord.Initialise(_firstPersonCharacter);
        _health.Initialise();
        _animationHandler.Initialise();
    }

    private void SetupComponent()
    {
        _animationHandler = GetComponentInChildren<PlayerAnimationHandler>();
        _movement = GetComponent<PlayerMovement>();
        _sound = GetComponent<PlayerSoundHandler>();
        _playerRecord = GetComponent<PlayerRecord>();
        _firstPersonCharacter = GetComponent<CMFirstPersonCharacter>();
        _health = GetComponent<HealthBody>();
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

    public void TakeDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}
