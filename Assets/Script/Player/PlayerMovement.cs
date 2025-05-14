using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IPlayerMovement
{
    [SerializeField] private Updater _updater;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerStateMachine _stateMachine;

    public Vector2 LookDirection { get; set; }
    public Vector2 Speed { get; set; }

    private void OnEnable()
    {
        _updater.OnUpdate += ComputeUpdate;
        _updater.OnFixedUpdate += ComputeFixedUpdate;
    }
    
    private void OnDisable()
    {
        _updater.OnUpdate -= ComputeUpdate;
        _updater.OnFixedUpdate -= ComputeFixedUpdate;
    }

    private void ComputeFixedUpdate()
    {
        ComputeVelocity();
    }
    private void ComputeUpdate()
    {
        _stateMachine.StateMachineUpdate();
    }
    
    private void ComputeVelocity()
    {
        Vector3 velocity = LookDirection * Speed;
        velocity.y = _rb.linearVelocityY;
        _rb.linearVelocity = velocity;
    }
    
    public void Jump(float jumpForce)
    {
        _rb.linearVelocity += Vector2.up * jumpForce;
    }




}
