using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using static UnityEditor.Experimental.GraphView.GraphView;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "Attack", story: "[Enemy] attack", category: "Action", id: "a9f064a51be0d3efe79fa5c0a1f0b1a4")]
public partial class AttackAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Enemy;

    protected override Status OnStart()
    {
        Collider[] colliders = Physics.OverlapSphere(Enemy.Value.transform.position + Enemy.Value.transform.forward * 1.14f, 1.48f);
        if (colliders != null && colliders.Length > 0)
        {
            foreach (Collider el in colliders)
            {
                IHealth otherHealth = el.GetComponent<IHealth>();
                if (otherHealth != null)
                {
                    otherHealth.TakeDamage(50f);
                }
            }
        }
        return Status.Success;
    }
}

