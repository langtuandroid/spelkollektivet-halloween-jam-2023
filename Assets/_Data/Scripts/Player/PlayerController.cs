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

    private void Awake()
    {
        SetupComponent();
        _playerRecord.Initialise(_firstPersonCharacter);
    }


    private void SetupComponent()
    {
        _animationHandler = GetComponentInChildren<PlayerAnimationHandler>();
        _movement = GetComponent<PlayerMovement>();
        _sound = GetComponent<PlayerSoundHandler>();
        _playerRecord = GetComponent<PlayerRecord>();
        _firstPersonCharacter = GetComponent<CMFirstPersonCharacter>();
    }
}
