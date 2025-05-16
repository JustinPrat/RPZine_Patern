using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour, IHealth
{
    [SerializeField] protected float maxHealth;
    protected float health = 100;
    
    public event Action OnTakeDamage;
    public event Action OnHeal;
    public event Action OnDeath;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }

    public void Heal(float amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);
        OnHeal?.Invoke();
    }

    public void Death()
    {
        //gameObject.SetActive(false);
        OnDeath?.Invoke();
    }
    public void TakeDamage(float amount)
    {
        health = Mathf.Clamp(health - amount, 0, maxHealth);
        Debug.Log($"Take {amount} damage");
        OnTakeDamage?.Invoke();
        if (health <= 0)
        {
            Death();
        }
    }
}
