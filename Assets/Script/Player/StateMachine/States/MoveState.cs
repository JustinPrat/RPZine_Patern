using System;
using UnityEngine;

[Serializable]
public class MoveState : PlayerState
{

    [Header("Metrics")] 
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _accelerationTime;
    [SerializeField] private AnimationCurve _accelerationCurve;

    private float _currentAccelerationTime;
    
    private ISpeedWriter SpeedWriter => _playerStateMachine.BasicMoverRef;
    private IInputDirectionReader Direction => _playerStateMachine.BasicMoverRef;

    public override void OnStateEnter(StateTypes previousState)
    {
        base.OnStateEnter(previousState);
        _currentAccelerationTime = 0;
    }   
    
    public override void OnStateUpdate()
    {
        base.OnStateUpdate();

        if (Direction.InputDirection != Vector2.zero)
        {
            if(_currentAccelerationTime >= _accelerationTime)
                return;
            _currentAccelerationTime = Mathf.Min( _currentAccelerationTime + Time.deltaTime, _accelerationTime);
            SpeedWriter.Speed = Mathf.Lerp(SpeedWriter.Speed, _maxSpeed, _accelerationCurve.Evaluate(_currentAccelerationTime / _accelerationTime));
        }
        else
        {
            _currentAccelerationTime = Mathf.Max( _currentAccelerationTime - Time.deltaTime, 0);
            SpeedWriter.Speed = Mathf.Lerp(SpeedWriter.Speed, 0, _accelerationCurve.Evaluate( 1 - (_currentAccelerationTime / _accelerationTime)));
        }
        
        if (SpeedWriter.Speed <= 0)
        {
            _playerStateMachine.ChangeState(StateTypes.Idle);
            return;
        }
    }
    

    
}