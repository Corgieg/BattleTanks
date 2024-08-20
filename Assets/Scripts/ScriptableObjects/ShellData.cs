using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShellData", menuName = "Data/ShellData")]
public class ShellData : ScriptableObject
{
    public int damage = 0;
    public float speed = 0.0f;
    public float maxDistance = 0.0f;
}
