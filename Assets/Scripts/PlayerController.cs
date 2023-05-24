using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : EntityBase
{
    public Vector3 MoveDirection { get; private set; }

    //Movimiento simple basado en Axis
    private void Update()
    {
        MoveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Move(MoveDirection.normalized);
        transform.forward = MoveDirection;
    }
}
