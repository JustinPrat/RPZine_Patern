using Reflex.Attributes;
using System;
using UnityEngine;

[Serializable]
public class PlayerStateMachine
{
    [Inject] private readonly Updater _updater;
    
    [Header("States")]
    [SerializeField] private IdleState _idleState;
    [SerializeField] private JumpState _jumpState;
    [SerializeField] private MoveState _moveState;
    
    private StateTypes _currentStateType;
    private IBasicMover _basicMoverRef;
    private PlayerState _currentState;
    private PlayerState[] _playerStates;

    private PlayerState[] PlayerStates
    {
        get
        {
            _playerStates = new PlayerState[]
            {
                _idleState,
                _jumpState,
                _moveState
            };
            return _playerStates;
        }
    }
    public IBasicMover BasicMoverRef => _basicMoverRef;

    public StateTypes CurrentStateType => _currentStateType;

    public void Init(IBasicMover basicMover)
    {
        _basicMoverRef = basicMover;
        foreach (PlayerState el in PlayerStates)
        {
            el.Init(this);
        }
    }
    
    public void ChangeState(StateTypes state)
    {
        _currentState?.OnStateExit(state);
        _currentState = GetPlayerState(state);
        _currentState?.OnStateEnter(CurrentStateType);
        _currentStateType = state; 
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
            case StateTypes.Jumping: return _jumpState;
            case StateTypes.Moving: return _moveState;
            case StateTypes.Farting:
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}
