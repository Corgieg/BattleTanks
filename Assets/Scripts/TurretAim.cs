using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAim : MonoBehaviour
{
    public float turretRotationSpeed = 200f;

    public void Aim(Vector2 pointerPosition)
    {
        var turretDirection = (Vector3)pointerPosition - transform.position;

        var desiredAngle = Mathf.Atan2(turretDirection.x, turretDirection.y) * Mathf.Rad2Deg;

        var rotationStep = turretRotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, -desiredAngle), rotationStep);
    }
}
