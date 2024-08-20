using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTurretData", menuName = "Data/TurretData")]
public class TurretData : ScriptableObject
{
    public GameObject projectilePrefab;
    public ShellData shellData;
    public float reloadDelay = 0;
}
