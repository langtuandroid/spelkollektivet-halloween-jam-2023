using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Jamen : MonoBehaviour
{
    [SerializeField] private Transform _pos01;
    [SerializeField] private Transform _pos02;
    [SerializeField] private float _time;
    private void Start()
    {
        transform.DOMove(_pos01.position,_time).SetEase(Ease.Linear);
        transform.DORotateQuaternion(_pos01.rotation,_time).SetEase(Ease.Linear);
    }
}
