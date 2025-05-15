using UnityEngine;

public class CollisionProxy : MonoBehaviour, IHealth
{
    [SerializeField] private EntityBrain brain;

    public float Health => brain.Health;

    public float MaxHealth => brain.MaxHealth;

    public void Heal(float amount)
    {
        brain.Heal(amount);
    }

    public void TakeDamage(float amount)
    {
        brain.TakeDamage(amount);
    }
}
