using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyController : EntityBase
{
    [SerializeField] private PlayerController player;
    private Vector3 _reverseDirection;

    private void Update()
    {
        _reverseDirection = new Vector3(player.MoveDirection.x, 0, -player.MoveDirection.z);
        
        Move(_reverseDirection);
    }
}
