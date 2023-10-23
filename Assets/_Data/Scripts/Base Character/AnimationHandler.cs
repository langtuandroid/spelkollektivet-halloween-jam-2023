using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] protected Animator _animator;

    protected virtual void  Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public virtual void Initialise()
    {

    }
}
