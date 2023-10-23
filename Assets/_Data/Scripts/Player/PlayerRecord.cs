using EasyCharacterMovement.Examples.Cinemachine.FirstPersonExample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecord : MonoBehaviour
{
    [SerializeField] private CMFirstPersonCharacter character;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private GameObject _prefab;
    private List<PositionInTime> positionInTime = new List<PositionInTime>();

    private void FixedUpdate()
    {
        positionInTime.Add(new PositionInTime(transform.position, character.GetVelocity(), transform.rotation));
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            SpawnGhost();
        }
    }

    private void SpawnGhost()
    {
        PastController pastController = Instantiate(_prefab).GetComponent<PastController>();
        pastController.SetPositionInTime(positionInTime);
    }

}
