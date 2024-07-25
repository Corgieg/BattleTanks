using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    public UnityEvent<Vector2> onMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> onMoveTurret = new UnityEvent<Vector2>();
    public UnityEvent onShoot = new UnityEvent();

    private void Awake()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetBodyMovement();
        GetTurretMovement();
        GetShootingInput();
    }

    private void GetBodyMovement()
    {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        onMoveBody?.Invoke(movementVector.normalized);
    }

    private void GetTurretMovement()
    {
        onMoveTurret?.Invoke(GetMousePosition());
    }

    private Vector2 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        return mouseWorldPosition;
    }

    private void GetShootingInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            onShoot?.Invoke();
        }
    }
}
