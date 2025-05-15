using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsHandler : MonoBehaviour
{
    private InputSystem_Actions _actions;

    private InputAction _move;
    private InputAction _look;
    private InputAction _fart;
    private InputAction _jump;

    public Vector2 MoveDirection => _move.ReadValue<Vector2>();
    public Vector2 LookDirection => _look.ReadValue<Vector2>();
    public event Action OnFart;
    public event Action OnJump;

    private void Awake()
    {
        _actions = new InputSystem_Actions();
        _move = _actions.Player.Move;
        _look = _actions.Player.Look;
        _fart = _actions.Player.Prout;
        _jump = _actions.Player.Jump;
    }

    private void OnEnable()
    {
        EnableMove();
        EnableJump();
        EnableFart();
        EnableLook();
    }

    private void OnDisable()
    {
        DisableMove();
        DisableFart();
        DisableJump();
        DisableLook();
    }

    #region Move
    private void EnableMove()
    {
        _move.Enable();
    }
    
    private void DisableMove()
    {
        _move.Disable();
    }
    #endregion

    #region Look
    private void EnableLook()
    {
        _look.Enable();
    }
    
    private void DisableLook()
    {
        _look.Enable();
    }
    #endregion

    #region Fart
    
    private void EnableFart()
    {
        _fart.Enable();
        _fart.started += RaiseOnFire;
    }
    
    private void DisableFart()
    {
        _fart.Enable();
        _fart.started -= RaiseOnFire;
    }

    private void RaiseOnFire(InputAction.CallbackContext _) => OnFart?.Invoke();

    #endregion

    #region Jump
    
    private void EnableJump()
    {
        _jump.Enable();
        _jump.started += RaiseOnJump;
    }
    
    private void DisableJump()
    {
        _jump.Enable();
        _jump.started -= RaiseOnJump;
    }

    
    private void RaiseOnJump(InputAction.CallbackContext _) => OnJump?.Invoke();

    #endregion


}
