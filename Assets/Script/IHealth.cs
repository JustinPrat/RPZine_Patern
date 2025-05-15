using UnityEngine;

public interface IHealth
{
    public float Health { get; }
    public float MaxHealth { get; }

    public abstract void TakeDamage(float amount);
    public abstract void Heal(float amount);
}
