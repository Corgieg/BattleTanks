using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootBehaviour : AIBehaviour
{
    public float shootingFOV = 60;

    public override void PerformAction(TankController tank, AIDetector detector)
    {
        if (TargetInFOV(tank, detector))
        {
            tank.HandleMoveBody(Vector2.zero);
            tank.HandleShoot();
        }
        tank.HandleMoveTurret(detector.Target.position);
    }

    private bool TargetInFOV(TankController tank, AIDetector detector)
    {
        var direction = detector.Target.position - tank.turretAimer.transform.position;
        if (Vector2.Angle(tank.turretAimer.transform.up, direction) < shootingFOV / 2)
            return true;
        
        return false;
    }
}
