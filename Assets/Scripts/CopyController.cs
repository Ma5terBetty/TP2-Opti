using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    private Vector3 _reverseDirection;
    Vector3 middle = new Vector3(0, 0, 5);

    private void Update()
    {
        //Aplicamos orientación invertida del jugador.
        _reverseDirection = new Vector3(player.MoveDirection.x, 0, -player.MoveDirection.z);
        transform.forward = -_reverseDirection;

        transform.position = MiddleDifference();
    }

    void FakePositionUpdate()
    {
        transform.position = MiddleDifference();
    }

    //Copio la posición del jugador en ejes X e Y y modifico el z según su posición contra el espejo.
    Vector3 MiddleDifference()
    {
        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = middle.z + (middle.z - player.transform.position.z);

        return new Vector3(x, y, z);
    }
}
