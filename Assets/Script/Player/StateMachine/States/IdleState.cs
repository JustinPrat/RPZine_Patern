using System;
using UnityEngine;

[Serializable]
public class IdleState : PlayerState
{
    private IJumper Jumper => _playerStateMachine.PlayerMovementRef;

    public override void OnStateEnter(StateTypes previousState)
    {
        base.OnStateEnter(previousState);
        
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
        Debug.Log("idling");
    }
}