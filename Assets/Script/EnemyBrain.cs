using UnityEngine;

public class EnemyBrain : MonoBehaviour, IHealth
{
    private float health;
    private float maxHealth;

    public float Health { get { return health; } }
    public float MaxHealth { get { return maxHealth; } }

    public void Heal(float amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);
    }

    public void TakeDamage(float amount)
    {
        health = Mathf.Clamp(health - amount, 0, maxHealth);
    }
}
