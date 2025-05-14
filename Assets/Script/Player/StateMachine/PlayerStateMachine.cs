using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [SerializeField] private Updater _updater;
    
    [Header("States")]
    [SerializeField] private IdleState _idleState;

    
    private StateTypes _currnentStateType;
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

    private void Awake()
    {
        _updater.OnUpdate += StateMachineUpdate;

        foreach (PlayerState el in PlayerStates)
        {
            el.Init(this);
        }
    }

    private void Start()
    {
        ChangeState(StateTypes.Idle);
    }


    private void OnDestroy()
    {
        _updater.OnUpdate -= StateMachineUpdate;
    }

    public void ChangeState(StateTypes state)
    {
        _currentState?.OnStateExit(state);
        _currentState = GetPlayerState(state);
        _currentState?.OnStateEnter(_currnentStateType);
        _currnentStateType = state; 
    }

    private void StateMachineUpdate()
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
