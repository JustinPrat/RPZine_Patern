using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "CheckForPlayer", story: "[Agent] detect [Player] and set [PlayerDetected]", category: "Action", id: "9c0d2b0bf394c0a0269985d231093df7")]
public partial class CheckForPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Player;
    [SerializeReference] public BlackboardVariable<bool> PlayerDetected;
    protected override Status OnStart()
    {
        PlayerDetected.Value = Vector3.Distance(Agent.Value.transform.position, Player.Value.transform.position) <= 5;
        return Status.Success;
    }
}

