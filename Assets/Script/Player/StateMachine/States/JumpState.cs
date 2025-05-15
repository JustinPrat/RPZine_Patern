using System;
using UnityEngine;

[Serializable]
public class JumpState : PlayerState
{

    [Header("Metrics")] 
    [SerializeField] private float _jumpDuration;
    [SerializeField] private float _jumpHeight;
    
    private IJumpExecuter Jumper => _playerStateMachine.BasicMoverRef;
    private IGravityWritter Gravity => _playerStateMachine.BasicMoverRef;
    private ISpeedReader SpeedReader => _playerStateMachine.BasicMoverRef;

    public override void OnStateEnter(StateTypes previousState)
    {
        base.OnStateEnter(previousState);
        ComputeJump();
    }
    
    public override void OnStateUpdate()
    {
        base.OnStateUpdate();
        Debug.Log(Jumper.LinearVelocity);
        if (Jumper.LinearVelocity.y <= 0)
        {
            OnTouchGruond(SpeedReader.Speed);
            return;
        }
    }

    private void ComputeJump()
    {
        float HalfDuration = _jumpDuration;
        float JumpVelocity = 2 * _jumpHeight / HalfDuration;
        float ComputeGravity = - 2 * _jumpHeight / (HalfDuration * HalfDuration);
        float GravityScale = - ComputeGravity / Mathf.Abs(Physics2D.gravity.y);

        Gravity.GravityScale = GravityScale;
        Jumper.Jump(JumpVelocity);
    }
}