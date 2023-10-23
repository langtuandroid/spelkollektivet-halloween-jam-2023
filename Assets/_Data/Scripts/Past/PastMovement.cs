using DG.Tweening;
using EasyCharacterMovement.Examples.Cinemachine.FirstPersonExample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastMovement : MonoBehaviour
{
    [SerializeField, ReadOnly] private PastAnimationHandler _animationHandler;

    private List<PositionInTime> _positionInTimes;
    private int _currentTimeCount = 0;
    private int _maxTimeCount = 0;

    public void Initialise(PastAnimationHandler animationHandler)
    {
        _animationHandler = animationHandler;
    }

    public void SetPositionInTime(List<PositionInTime> positionInTimes)
    {
        _positionInTimes = positionInTimes;
        _maxTimeCount = _positionInTimes.Count;
        _currentTimeCount = 0;
    }

    public void RunTimeLoop()
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

    private void MoveInTime(int index, float time)
    {
        transform.DOMove(_positionInTimes[index].Position, time).SetEase(Ease.Linear);
        transform.DORotateQuaternion(_positionInTimes[index].Quaternion, time).SetEase(Ease.Linear);
        _animationHandler.SetMovement(_positionInTimes[index].Velocity.magnitude);
        _animationHandler.SetIsOnGround(_positionInTimes[index].IsOnGround);
        _currentTimeCount += 1;
    }

    private void ResetGhost()
    {
        transform.position = _positionInTimes[0].Position;
        transform.rotation = _positionInTimes[0].Quaternion;
        _currentTimeCount = 0;
    }
}
