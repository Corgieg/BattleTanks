using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public TankMovementData movementData;

    [SerializeField]
    private float currentSpeed = 0.0f;
    private Vector2 movementVector;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move(movementVector);
    }

    public void SetMovementVector(Vector2 movementVector)
    {
        this.movementVector = movementVector;
    }

    private void Move(Vector2 input)
    {
        CalculateSpeed(input);

        rb.velocity = (Vector2)transform.up * currentSpeed * Time.fixedDeltaTime;

        if (Mathf.Abs(input.x) > 0)
            rb.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -input.x * movementData.rotationSpeed * Time.fixedDeltaTime));
        else
            rb.MoveRotation(transform.rotation);
    }

    private void CalculateSpeed(Vector2 input)
    {
        switch (input.y)
        {
            case > 0:
                if (currentSpeed < 0)
                    currentSpeed += movementData.breaks * Time.deltaTime;
                else
                    currentSpeed += movementData.accelerationForward * Time.deltaTime;
                break;
            case < 0:
                if (currentSpeed > 0)
                    currentSpeed -= movementData.breaks * Time.deltaTime;
                else
                    currentSpeed -= movementData.accelerationReverse * Time.deltaTime;
                break;
            default:
                switch (currentSpeed)
                {
                    case > 1:
                        currentSpeed -= movementData.deacceleration * Time.deltaTime;
                        break;
                    case < -1:
                        currentSpeed += movementData.deacceleration * Time.deltaTime;
                        break;
                    default:
                        currentSpeed = 0;
                        break;
                }
                break;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -movementData.maxSpeedReverse, movementData.maxSpeedForward);
    }
}
