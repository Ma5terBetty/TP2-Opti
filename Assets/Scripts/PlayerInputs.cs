using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [SerializeField] private EntityController entity;
    [SerializeField] private CameraZoom zoom;
    [SerializeField] private CanvasController canvas;

    private bool _hasEntity;
    private bool _hasZoom;
    private bool _hasCanvas;
    
    private void Start()
    {
        _hasEntity = entity != null;
        _hasZoom = zoom != null;
        _hasCanvas = canvas != null;
    }

    private void Update()
    {
        
        if (_hasCanvas)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                canvas.SkipSplash();
            }
            
            else if (Input.GetKeyDown(KeyCode.P))
            {
                canvas.GoToPause();
            }
        }
        

        if (_hasZoom)
        {
            var scroll = Input.GetAxis("Mouse ScrollWheel");
            zoom.DoZoom(scroll);
        
            if (Input.GetMouseButtonDown(1))
            {
                zoom.ResetValue();
            } 
        }

        if (!GameManager.Instance.IsPaused)
        {
            if (Input.GetMouseButtonDown(0) && _hasEntity)
            {
                entity.SetTargetPos();
            }
        }
    }
}