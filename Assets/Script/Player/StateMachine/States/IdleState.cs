using System;
using UnityEngine;

[Serializable]
public class IdleState : PlayerState
{
    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
        Debug.Log("idling");
    }
}