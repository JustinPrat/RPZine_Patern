using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputsHandler : MonoBehaviour
{
    private InputSystem_Actions _actions;

    private InputAction _move;
    private InputAction _reload;
    private InputAction _fart;
    private InputAction _jump;

    public Vector2 MoveDirection => _move.ReadValue<Vector2>();
    public event Action OnReloadInputPressed;
    public event Action OnFartInputPressed;
    public event Action OnJumpInputPressed;

    private void Awake()
    {
        _actions = new InputSystem_Actions();
        _move = _actions.Player.Move;
        _reload = _actions.Player.Reload;
        _fart = _actions.Player.Prout;
        _jump = _actions.Player.Jump;
    }

    private void OnEnable()
    {
        EnableMove();
        EnableJump();
        EnableFart();
        EnableReload();
    }

    private void OnDisable()
    {
        DisableMove();
        DisableFart();
        DisableJump();
        DisableReload();
    }

    public void KillInput()
    {
        DisableMove();
        DisableFart();
        DisableJump();
        DisableReload();
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

    #region Reload
    private void EnableReload()
    {
        _reload.Enable();
        _reload.started += RaiseReload;
    }
    
    private void DisableReload()
    {
        _reload.Disable();
        _reload.started -= RaiseReload;
    }

    private void RaiseReload(InputAction.CallbackContext _) => OnReloadInputPressed?.Invoke();
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

    private void RaiseOnFire(InputAction.CallbackContext _) => OnFartInputPressed?.Invoke();

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

    
    private void RaiseOnJump(InputAction.CallbackContext _) => OnJumpInputPressed?.Invoke();

    #endregion


}
