using System;
using UnityEngine;

public class PlayerPhysic : MonoBehaviour, IBasicMover
{
    [Header("References")]
    [SerializeField] private Rigidbody _rb;
    private PlayerInputsHandler _inputsHandler;

    
    [Header("Metric")]
    [SerializeField] private float _rotationSpeed;
        
    private Vector2 _lookDirection;
    private Vector2 _inputDirection;
    private Vector2 _lastNonNullDirection;
    private float _currentSpeed;

    public event Action OnJumpInputPressed;
    public event Action<float> OnSpeedUpdated;

    
    public float GravityScale { get; set; }
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
    public float Speed
    {
        get => _currentSpeed;
        set
        {
            _currentSpeed = value;
            OnSpeedUpdated?.Invoke(_currentSpeed);
        }
    }
    
    
    private void OnDestroy()
    {
        _inputsHandler.OnJumpInputPressed -= RaiseJumpInputPressedInputPressed;
    }

    public void Init(PlayerInputsHandler inputs)
    {
        _inputsHandler = inputs;
        _inputsHandler.OnJumpInputPressed += RaiseJumpInputPressedInputPressed;
    }
    
    public void ComputeFixedUpdate()
    {
        ComputeVelocity();
    }
    public void ComputeUpdate()
    {
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
        if (InputDirection != Vector2.zero)
            _lastNonNullDirection = InputDirection;
        
        float targetAngle = Mathf.Atan2(_lastNonNullDirection.x, _lastNonNullDirection.y) * Mathf.Rad2Deg;

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

    public void RaiseJumpInputPressedInputPressed() => OnJumpInputPressed?.Invoke();

}
