using System;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    [SerializeField] private Updater _updater;
    [SerializeField] private PlayerPhysic _playerPhysic;
    [SerializeField] private PlayerStateMachine _stateMachine;
    [SerializeField] private PlayerInputsHandler _inputsHandler;
    

    private void Awake()
    {
        _updater.OnUpdate += PlayerUpdate;
        _updater.OnFixedUpdate += PlayerFixedUpdate;
        
        InitComponents();
    }

    private void OnDestroy()
    {
        _updater.OnUpdate -= PlayerUpdate;
        _updater.OnFixedUpdate -= PlayerFixedUpdate;
    }

    private void InitComponents()
    {
        _stateMachine.Init(_playerPhysic);
        _playerPhysic.Init(_inputsHandler);
    }

    private void Start()
    {
        _stateMachine.Init(_playerPhysic);
        _stateMachine.ChangeState(StateTypes.Idle);
    }

    private void PlayerFixedUpdate()
    {
        _playerPhysic.ComputeFixedUpdate();
    }

    private void PlayerUpdate()
    {
        _playerPhysic.ComputeUpdate();
        _stateMachine.ComputeUpdate();
    }
    
    
#if UNITY_EDITOR
    private void OnGUI()
    {
        GUILayout.Label($"Player State: {_stateMachine.CurrentStateType}");
        GUILayout.Label($"Player speed: {_playerPhysic.Speed}");
    }
#endif
}
