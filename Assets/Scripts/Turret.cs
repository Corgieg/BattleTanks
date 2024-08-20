using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class Turret : MonoBehaviour
{
    public List<Transform> turretBarrels;
    public TurretData turretData;

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    private float currentDelay = 0;

    private ObjectPool shellPool;
    [SerializeField]
    private int shellPoolCount = 10;

    private void Awake()
    {
        tankColliders = GetComponentsInParent<Collider2D>();
        shellPool = GetComponent<ObjectPool>();
    }

    private void Start() {
        shellPool.Initialize(turretData.projectilePrefab, shellPoolCount); 
    }

    private void Update()
    {
        if (!canShoot)
        {
            currentDelay -= Time.deltaTime;
            if (currentDelay <= 0)
                canShoot = true;
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = turretData.reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                GameObject projectile = shellPool.CreateObject();
                projectile.transform.position = barrel.position;
                projectile.transform.localRotation = barrel.rotation;
                projectile.GetComponent<Shell>().Initialize(turretData.shellData);
                foreach (var collider in tankColliders)
                {
                    Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), collider);
                }
            }
        }
    }
}
