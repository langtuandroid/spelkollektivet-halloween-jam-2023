using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RagDoll : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private Collider[] _colliders;


    public void Initialise()
    {
        _animator = GetComponent<Animator>();
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
    }

    public void ActivateRagdoll(bool activate)
    {
        if (activate)
        {
            _animator.enabled = false;

            foreach (Rigidbody rigidbody in _rigidbodies)
            {
                rigidbody.isKinematic = false;
            }

            foreach (Collider collider in _colliders)
            {
                collider.isTrigger = false;
            }
        }
        else
        {
            _animator.enabled = true;

            foreach (Rigidbody rigidbody in _rigidbodies)
            {
                rigidbody.isKinematic = true;
            }

            foreach (Collider collider in _colliders)
            {
                collider.isTrigger = true;
            }
        }
    }


    [ContextMenu("Make Body Part")]
    private void MakeBodyPart()
    {
        Initialise();

        foreach (var item in _colliders)
        {
            BodyPart bodyPart = item.GetComponent<BodyPart>();

            if (bodyPart == null)
            {
                bodyPart = item.AddComponent<BodyPart>();
            }

            if(bodyPart.name == "Head")
            {
                bodyPart.DamageScale = 2;
            }
        }
    }
}
