using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TankMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxSpeedForward = 70.0f;
    public float maxSpeedReverse = 45.0f;
    public float accelerationForward = 70.0f;
    public float accelerationReverse = 45.0f;
    public float breaks = 90.0f;
    public float deacceleration = 25.0f;
    public float rotationSpeed = 140.0f;

    [SerializeField] private float currentSpeed = 0.0f;
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
            rb.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -input.x * rotationSpeed * Time.fixedDeltaTime));
        else
            rb.MoveRotation(transform.rotation);
    }

    private void CalculateSpeed(Vector2 input)
    {
        switch (input.y)
        {
            case > 0:
                if (currentSpeed < 0)
                    currentSpeed += breaks * Time.deltaTime;
                else
                    currentSpeed += accelerationForward * Time.deltaTime;
                break;
            case < 0:
                if (currentSpeed > 0)
                    currentSpeed -= breaks * Time.deltaTime;
                else
                    currentSpeed -= accelerationReverse * Time.deltaTime;
                break;
            default:
                switch (currentSpeed)
                {
                    case > 1:
                        currentSpeed -= deacceleration * Time.deltaTime;
                        break;
                    case < -1:
                        currentSpeed += deacceleration * Time.deltaTime;
                        break;
                    default:
                        currentSpeed = 0;
                        break;
                }
                break;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeedReverse, maxSpeedForward);
    }
}
