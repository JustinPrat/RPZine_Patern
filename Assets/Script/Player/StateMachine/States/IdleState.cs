using System;
using UnityEngine;

[Serializable]
public class IdleState : PlayerState
{
    private IJumpRequester Jumper => _playerStateMachine.BasicMoverRef;
    private IInputDirectionReader Input => _playerStateMachine.BasicMoverRef;

    public override void OnStateEnter(StateTypes previousState)
    {
        base.OnStateEnter(previousState);
        Jumper.OnJumpInputPressed += JumpPressed;
    }

    public override void OnStateExit(StateTypes newState)
    {
        base.OnStateExit(newState);
        Jumper.OnJumpInputPressed -= JumpPressed;
    }

    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
        if (Input.InputDirection != Vector2.zero)
        {
            _playerStateMachine.ChangeState(StateTypes.Moving);
            return;
        }
    }
}