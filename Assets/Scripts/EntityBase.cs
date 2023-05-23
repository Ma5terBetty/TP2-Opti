using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class EntityBase : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction)
    {
        var dirSpeed = direction * speed;
        dirSpeed.y = _rb.velocity.y;
        _rb.velocity = dirSpeed;
    }
}
