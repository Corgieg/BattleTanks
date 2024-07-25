using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public List<Transform> turretBarrels;
    public GameObject projectilePrefab;
    public float reloadDelay = 1;

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    private float currentDelay = 0;

    private void Awake()
    {
        tankColliders = GetComponentsInParent<Collider2D>();
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
            currentDelay = reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                GameObject projectile = Instantiate(projectilePrefab);
                projectile.transform.position = barrel.position;
                projectile.transform.localRotation = barrel.rotation;
                projectile.GetComponent<Shell>().Initialize();
                foreach (var collider in tankColliders)
                {
                    Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), collider);
                }
            }
        }
    }
}
