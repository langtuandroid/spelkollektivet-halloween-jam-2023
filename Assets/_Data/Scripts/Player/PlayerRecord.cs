using EasyCharacterMovement.Examples.Cinemachine.FirstPersonExample;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecord : MonoBehaviour
{
    [SerializeField] private CMFirstPersonCharacter _character;

    [SerializeField] private GameObject _prefab;
    private List<PositionInTime> positionInTime = new List<PositionInTime>();

    public void Initialise(CMFirstPersonCharacter character)
    {
        _character = character;
        print("aaa");
    }

    private void FixedUpdate()
    {
        positionInTime.Add(new PositionInTime(transform.position, _character.GetVelocity(), transform.rotation));
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
