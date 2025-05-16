using System;
using UnityEngine;

public class PlayerBrain : EntityBrain
{
    [Header("Logic")]
    [SerializeField] private PlayerPhysic _playerPhysic;
    [SerializeField] private PlayerStateMachine _stateMachine;
    [SerializeField] private PlayerInputsHandler _inputsHandler;
    [SerializeField] private FartBehaviour _fartBehaviour;
    [SerializeField] private AnimationHandler _animationHandler;
    
    [Header("UI")] 
    [SerializeField] private HealthUi _healthUi;
    [SerializeField] private FartUi _fartUi;

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
   protected override void InitComponents()
    {
        base.InitComponents();
        _stateMachine.Init(_playerPhysic);
        _playerPhysic.Init(_inputsHandler);
        _fartBehaviour.Init(_inputsHandler);
        _animationHandler.Init(_fartBehaviour, _playerPhysic, _healthComponent);
        _healthUi.Init(_healthComponent);
        _fartUi.Init(_fartBehaviour);
    }

    private void Start()
    {
        _stateMachine.Init(_playerPhysic);
        _stateMachine.ChangeState(StateTypes.Idle);
    }

    protected override void PlayerFixedUpdate()
    {
        base.PlayerFixedUpdate();
        _playerPhysic.ComputeFixedUpdate();
    }

    protected override void PlayerUpdate()
    {
        base.PlayerUpdate();
        _playerPhysic.ComputeUpdate();
        _stateMachine.ComputeUpdate();
        _fartBehaviour.ComputeUpdate();
        _healthUi.ComputeUpdate();
    }
    
    
#if UNITY_EDITOR
    private void OnGUI()
    {
        GUILayout.Label($"Player State: {_stateMachine.CurrentStateType}");
        GUILayout.Label($"Player speed: {_playerPhysic.Speed}");
        GUILayout.Label($"Fart amount: {_fartBehaviour.CurrentFartAmount}");
        GUILayout.Label($"Fart reload: {_fartBehaviour.CurrentReloadTime}");
        GUILayout.Label($"Fart cooldown: {_fartBehaviour.CurrentCoolDownTime}");
    }
#endif
}
