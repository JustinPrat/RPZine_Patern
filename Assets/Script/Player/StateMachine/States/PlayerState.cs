using System;

public class PlayerState
{
    protected PlayerStateMachine _playerStateMachine;

    public virtual void Init(PlayerStateMachine stateMachine)
    {
        _playerStateMachine = stateMachine;
    }
    
    public virtual void OnStateEnter(StateTypes previousState) {}
    public virtual void OnStateUpdate() {}
    public virtual void OnStateExit(StateTypes newState) {}
}
