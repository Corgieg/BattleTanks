using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public ShellData shellData;

    private Vector2 startPosition;
    private float conquaredDistance = 0;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(ShellData shellData)
    {
        this.shellData = shellData;
        startPosition = transform.position;
        rb.velocity = transform.up * shellData.speed;
    }

    // Update is called once per frame
    void Update()
    {
        conquaredDistance = Vector2.Distance(transform.position, startPosition);
        if (conquaredDistance >= shellData.maxDistance)
        {
            Debug.Log("Miss...");
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit! " + collision.name);

        var damageable = collision.GetComponent<Damageable>();
        if (damageable != null)
            damageable.Hit(shellData.damage);
        
        DisableObject();
    }
}
