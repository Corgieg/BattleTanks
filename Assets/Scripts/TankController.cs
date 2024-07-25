using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public TankMove tankMover;
    public TurretAim turretAimer;
    public Turret[] turrets;

    private void Awake()
    {
        if (tankMover == null)
        {
            tankMover = GetComponentInChildren<TankMove>();
        }

        if (turretAimer == null)
        {
            turretAimer = GetComponentInChildren<TurretAim>();
        }

        if (turrets == null || turrets.Length == 0 )
        {
            turrets = GetComponentsInChildren<Turret>();
        }
    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        tankMover.SetMovementVector(movementVector);
    }

    public void HandleMoveTurret(Vector2 pointerPosition)
    {
        turretAimer.Aim(pointerPosition);
    }

    public void HandleShoot()
    {
        foreach (Turret t in turrets)
        {
            t.Shoot();
        }
    }
}
