using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class EntityBase : MonoBehaviour
{
    [Range(1,10)][SerializeField] private float movementSpeed = 5f;
    [Range(1,100)][SerializeField] private float rotationSpeed = 5f;

    private Rigidbody _rb;
    private Quaternion _targetRotation;

    public Vector3 Position => transform.position;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        var dirSpeed = direction * movementSpeed;
        dirSpeed.y = _rb.velocity.y;
        _rb.velocity = dirSpeed;
    }

    public void Rotate(Vector3 direction)
    {
        if (direction == Vector3.zero) return;
        direction.y = 0;
        var newRotation = Vector3.RotateTowards(transform.forward, direction, rotationSpeed * Time.deltaTime, 0.0f);
        transform.rotation= Quaternion.LookRotation(newRotation);  
    }
}
