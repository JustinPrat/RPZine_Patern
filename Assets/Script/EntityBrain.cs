using Reflex.Attributes;
using UnityEngine;

public class EntityBrain : MonoBehaviour
{
    [Inject] protected readonly Updater _updater;
    [SerializeField] protected HealthComponent _healthComponent;

    protected virtual void InitComponents()
    {
        _healthComponent.Init();
    }

    protected virtual void PlayerFixedUpdate()
    {
        
    }

    protected virtual void PlayerUpdate()
    {
        
    }
}