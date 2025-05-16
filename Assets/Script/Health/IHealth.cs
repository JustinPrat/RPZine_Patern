using System;

public interface IHealth
{
    public float Health { get; }
    public float MaxHealth { get; }

    public abstract void TakeDamage(float amount);
    public abstract void Heal(float amount);
    public abstract void Death();

    public event Action OnTakeDamage;
    public event Action OnHeal;
    public event Action OnDeath;
}
