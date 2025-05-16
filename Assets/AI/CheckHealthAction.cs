using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CheckHealth", story: "Check [SelfHealth] and set [isDead]", category: "Action", id: "da962f062380b6b2d80af3e4c698a5d7")]
public partial class CheckHealthAction : Action
{
    [SerializeReference] public BlackboardVariable<HealthComponent> SelfHealth;
    [SerializeReference] public BlackboardVariable<bool> IsDead;
    protected override Status OnStart()
    {
        IsDead.Value = SelfHealth.Value.Health <= 0;
        return Status.Success;
    }

}

