using Reflex.Attributes;
using UnityEngine;

public class EntityBrain : MonoBehaviour, IHealth
{
    [Inject] protected readonly Updater _updater;

    protected float health;
    protected float maxHealth;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }

    public void Heal(float amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);
    }

    public void TakeDamage(float amount)
    {
        health = Mathf.Clamp(health - amount, 0, maxHealth);
        Debug.Log($"Take {amount} damage");
    }
}