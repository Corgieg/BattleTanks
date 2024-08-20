using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTankMovementData", menuName = "Data/TankMovementData")]
public class TankMovementData : ScriptableObject
{
    public float maxSpeedForward = 0.0f;
    public float maxSpeedReverse = 0.0f;
    public float accelerationForward = 0.0f;
    public float accelerationReverse = 0.0f;
    public float breaks = 0.0f;
    public float deacceleration = 0.0f;
    public float rotationSpeed = 0.0f;
}
