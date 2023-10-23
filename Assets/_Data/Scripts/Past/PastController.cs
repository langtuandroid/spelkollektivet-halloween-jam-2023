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

    private List<PositionInTime> _positionInTimes;
    private int _currentTimeCount = 0;
    private int _maxTimeCount = 0;



    private void Awake()
    {
        SetupComponent();
    }


    private void FixedUpdate()
    {
        RunTimeLoop();
    }

    private void SetupComponent()
    {
        _animationHandler = GetComponentInChildren<PastAnimationHandler>();
        _movement = GetComponent<PastMovement>();
        _shooting = GetComponent<PastShooting>();
        _sound = GetComponent<PastSoundHandler>();
    }

    public void SetPositionInTime(List<PositionInTime> positionInTimes)
    {
        _positionInTimes = positionInTimes;
        _maxTimeCount = _positionInTimes.Count;
        _currentTimeCount = 0;
    }

    private void RunTimeLoop()
    {
        if (_currentTimeCount < _maxTimeCount)
        {
            MoveInTime(_currentTimeCount, Time.fixedDeltaTime);
            if (_currentTimeCount == _maxTimeCount - 1)
            {
                ResetGhost();
            }
        }
    }

    private void MoveInTime(int index,float time)
    {
        transform.DOMove(_positionInTimes[index].Position, time).SetEase(Ease.Linear);
        transform.DORotateQuaternion(_positionInTimes[index].Quaternion, time).SetEase(Ease.Linear);
        _animationHandler.SetMovement(_positionInTimes[index].Velocity.magnitude);
        _currentTimeCount += 1;
    }

    private void ResetGhost()
    {
        transform.position = _positionInTimes[0].Position;
        transform.rotation = _positionInTimes[0].Quaternion;
        _currentTimeCount = 0;
    }

    private void StopTween()
    {

    }

    private void OnDisable()
    {
        StopTween();
    }
}
