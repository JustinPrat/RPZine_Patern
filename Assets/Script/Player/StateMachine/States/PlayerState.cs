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

    protected void JumpPressed()
    {
        _playerStateMachine.ChangeState(StateTypes.Jumping);
    }

    protected void OnTouchGruond(float speed)
    {
        _playerStateMachine.ChangeState(speed > 0 ? StateTypes.Moving : StateTypes.Idle);
    }
}
