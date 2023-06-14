using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [Range(1,10)][SerializeField] private float multiplier = 4;
    [Range(1,30)][SerializeField] private float min = 2;
    [Range(1,30)][SerializeField] private float max = 30;
    [SerializeField] private float velocity = 5;
    [Range(0.1f, 1f)][SerializeField] private float smoothTime = 0.25f;

    private Camera _camera;
    private float _current;

    private float _startValue;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Start()
    {
        _current = _camera.orthographicSize;
        _startValue = _current;
    }

    public void DoZoom(float scroll)
    {
        _current -= scroll * multiplier;
        _current = Mathf.Clamp(_current, min, max);
        _camera.orthographicSize = Mathf.SmoothDamp(_camera.orthographicSize, _current, ref velocity, smoothTime);
    }

    public void ResetValue()
    {
        _current = _startValue;
        _camera.orthographicSize = Mathf.SmoothDamp(_camera.orthographicSize, _current, ref velocity, smoothTime);
    }
}
