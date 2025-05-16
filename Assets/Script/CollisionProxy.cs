using System;
using UnityEngine;

public class CollisionProxy : MonoBehaviour, IHealth
{
    [SerializeField] private HealthComponent brain;

    public float Health => brain.Health;

    public float MaxHealth => brain.MaxHealth;

    public void Heal(float amount)
    {
        brain.Heal(amount);
    }

    public void Death()
    {
        brain.Death();
    }
    public void TakeDamage(float amount)
    {
        brain.TakeDamage(amount);
    }

    public event Action OnTakeDamage;
    public event Action OnHeal;
    public event Action OnDeath;


}
