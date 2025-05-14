using System;
using UnityEngine;

[Serializable]
public class PlayerStateMachine
{
    [Header("States")]
    [SerializeField] private IdleState _idleState;
    
    private StateTypes _currnentStateType;
    private IPlayerMovement _playerMovementRef;
    private PlayerState _currentState;
    private PlayerState[] _playerStates;

    private PlayerState[] PlayerStates
    {
        get
        {
            _playerStates = new PlayerState[]
            {
                _idleState
            };
            return _playerStates;
        }
    }
    public IPlayerMovement PlayerMovementRef => _playerMovementRef;

    public void Init(IPlayerMovement playerMovement)
    {
        _playerMovementRef = playerMovement;
        foreach (PlayerState el in PlayerStates)
        {
            el.Init(this);
        }
        ChangeState(StateTypes.Idle);
    }
    
    public void ChangeState(StateTypes state)
    {
        _currentState?.OnStateExit(state);
        _currentState = GetPlayerState(state);
        _currentState?.OnStateEnter(_currnentStateType);
        _currnentStateType = state; 
    }

    public void StateMachineUpdate()
    {
        if(_currentState == null)
            return;
        
        _currentState.OnStateUpdate();
    }

    private PlayerState GetPlayerState(StateTypes type)
    {
        switch (type)
        {
            case StateTypes.Idle: return _idleState;
            case StateTypes.Moving:
            case StateTypes.Jumping:
            case StateTypes.Farting:
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}
