using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public int MaxHealth = 100;
    [SerializeField]
    private int health;

    public int Health {
        get => health;
        set {
            health = value;
            OnHealthChange?.Invoke((float)Health / MaxHealth);
        }
    }

    public UnityEvent OnDead;
    public UnityEvent<float> OnHealthChange;
    public UnityEvent OnHit, OnHeal;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    internal void Hit(int damage) {
        Health -= damage;

        if (Health <= 0)
            OnDead?.Invoke();
        else
            OnHit?.Invoke();
    }

    public void Heal(int healing) {
        Health += healing;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        OnHeal?.Invoke();
    }
}
