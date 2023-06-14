using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private Collider planeCollider;
    [SerializeField] private float minDistanceToPos = 0.5f;

    private RaycastHit _hit;
    private Ray _ray;
    private EntityBase _model;
    private bool _isModelNull;
    private Vector3 _targetPosition;
    private Vector3 _targetDirection;
    

    private void Awake()
    {
        _model = GetComponent<EntityBase>();
    }

    private void Start()
    {
        _isModelNull = _model == null;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPos();
        }

        if (!IsCloseToTargetPoint())
        {
            Movement();
        }
    }

    private void SetTargetPos()
    {
        if (_isModelNull) return;
        
        _ray = camera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(_ray, out _hit)) return;
        if (_hit.collider != planeCollider) return;
        
        _targetPosition = _hit.point;
        _targetDirection = (_targetPosition - _model.Position).normalized;
    }

    private void Movement()
    {
        if(_isModelNull) return;
        
        _model.Move(_targetDirection);
        _model.Rotate(_targetDirection);
    }

    private bool IsCloseToTargetPoint()
    {
        if (_isModelNull)
            return false;
        
        var dist =  Vector3.Distance(_model.Position, _targetPosition);
        return dist <= minDistanceToPos;
    }


}
