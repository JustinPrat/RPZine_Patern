using System;
using UnityEngine;
using UnityEngine.Events;

public class FartBehaviour : MonoBehaviour, IFarter
{
    private PlayerInputsHandler _inputs;

    [Header("Fart Area")] 
    [SerializeField] private float _fartAreaOffset;
    [SerializeField] private float _fartRadius;
    [SerializeField] private LayerMask _layers;
    
    [Header("Fart Metrics")]
    [SerializeField] private int _fartAmount;
    [SerializeField] private float _fartDamageOuput;
    [SerializeField] private float _fartReloadTime;
    [SerializeField] private float _fartCoolDownTime;
    private int _currentFartAmount;
    private float _currentReloadTime;
    private float _currentCoolDownTime;
    private bool _isInCoolDown;
    private bool _isReloading;
    
    public event Action OnFart;
    public event Action OnReload;
    public event Action OnReloadComplete;
    
    public UnityEvent OnFartUnityEvent;
    public UnityEvent OnReloadUnityEvent;

    public int FartAmount => _fartAmount;
    public int CurrentFartAmount => _currentFartAmount;
    public float CurrentReloadTime => _currentReloadTime;
    public float CurrentCoolDownTime => _currentCoolDownTime;


    public void Init(PlayerInputsHandler inputs)
    {
        _inputs = inputs;

        _inputs.OnFartInputPressed += Fart;
        _inputs.OnReloadInputPressed += Reload;

        _currentFartAmount = FartAmount;
    }

    private void OnDestroy()
    {
        _inputs.OnFartInputPressed -= Fart;
        _inputs.OnReloadInputPressed -= Reload;
    }

    public void ComputeUpdate()
    {
        ComputeReload();
        ComputeCoolDown();
    }

    private void ComputeReload()
    {
        if(!_isReloading)
            return;

        _currentReloadTime = CurrentReloadTime + Time.deltaTime;
        if (CurrentReloadTime > _fartReloadTime)
        {
            _isReloading = false;
            _currentFartAmount = FartAmount;
            _currentReloadTime = 0;
            RaiseReloadComplete();
        }
    }
    
    private void ComputeCoolDown()
    {
        if(!_isInCoolDown)
            return;

        _currentCoolDownTime = CurrentCoolDownTime + Time.deltaTime;
        if (CurrentCoolDownTime > _fartCoolDownTime)
        {
            _isInCoolDown = false;
            _currentCoolDownTime = 0;
        }
    }

    public void Fart()
    {
        if(CurrentFartAmount <= 0 || _isReloading || _isInCoolDown)
            return;

        _currentFartAmount = CurrentFartAmount - 1;
        _isInCoolDown = true;
        RaiseFartInputPressed();
        
        Collider[] colliders = Physics.OverlapSphere(transform.position + transform.forward * _fartAreaOffset, _fartRadius, _layers);
        if (colliders != null && colliders.Length > 0)
        {
            foreach (Collider el in colliders)
            {
                if (TryGetComponent(typeof(IHealth), out Component iHealth))
                {
                    ((IHealth)iHealth).TakeDamage(_fartDamageOuput);
                }
            }
        }
        
    }

    public void Reload()
    {
        if(_isReloading)
            return;

        _isReloading = true;
        RaiseReloadInputPressed();
    }



    public void RaiseFartInputPressed()
    {
        OnFart?.Invoke();
        OnFartUnityEvent?.Invoke();
    }

    public void RaiseReloadInputPressed()
    {
        OnReload?.Invoke();
        OnReloadUnityEvent?.Invoke();
    }

    public void RaiseReloadComplete()
    {
        OnReloadComplete?.Invoke();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward * _fartAreaOffset, _fartRadius);
    }
}
