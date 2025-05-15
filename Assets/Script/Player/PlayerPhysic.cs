using System;
using UnityEngine;

public class PlayerPhysic : MonoBehaviour, IBasicMover
{
    [SerializeField] private Updater _updater;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private PlayerStateMachine _stateMachine;
    [SerializeField] private PlayerInputsHandler _inputsHandler;

    [SerializeField] private float _rotationSpeed;

    private Vector2 _lookDirection;
    private Vector2 _inputDirection;
    

    public event Action OnJumpInputPressed;
    
    public float GravityScale { get; set; }
    public float Speed { get; set; }

    public Vector2 LinearVelocity => _rb.linearVelocity;
    public Vector2 LookDirection
    {
        get => _lookDirection;
        set => _lookDirection = value;
    }
    public Vector2 InputDirection
    {
        get => _inputDirection;
        set => _inputDirection = value;
    }


    private void OnEnable()
    {
        _updater.OnUpdate += ComputeUpdate;
        _updater.OnFixedUpdate += ComputeFixedUpdate;
        _inputsHandler.OnJump += RaiseJumpInputPressed;
    }
    
    private void OnDisable()
    {
        _updater.OnUpdate -= ComputeUpdate;
        _updater.OnFixedUpdate -= ComputeFixedUpdate;
        _inputsHandler.OnJump -= RaiseJumpInputPressed;
    }

    private void Start()
    {
        _stateMachine.Init(this);
        _stateMachine.ChangeState(StateTypes.Idle);
    }
        
    private void ComputeFixedUpdate()
    {
        ComputeVelocity();
    }
    private void ComputeUpdate()
    {
        _stateMachine.StateMachineUpdate();
        ComputeInputs();
        ComputeOrientation();
    }
    
    private void ComputeVelocity()
    {
        Vector3 velocity = transform.forward * Speed;
        velocity.y = _rb.linearVelocity.y;
        _rb.linearVelocity = velocity;
    }

    private void ComputeOrientation()
    {
        float targetAngle = Mathf.Atan2(InputDirection.x, InputDirection.y) * Mathf.Rad2Deg;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, targetAngle, 0f));
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }

    private void ComputeInputs()
    {
        _inputDirection = _inputsHandler.MoveDirection;
    }
    
    
    public void Jump(float jumpForce)
    {
        _rb.linearVelocity = Vector3.up * jumpForce;
        Debug.Log(_rb.linearVelocity);
    }

    public void RaiseJumpInputPressed() => OnJumpInputPressed?.Invoke();

#if UNITY_EDITOR
    private void OnGUI()
    {
        GUILayout.Label($"Player State: {_stateMachine.CurrentStateType}");
        GUILayout.Label($"Player speed: {Speed}");
    }
#endif
}
