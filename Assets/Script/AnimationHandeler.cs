using System;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private IFarter _fartBehaviour;
    private ISpeedReader _speedReader;
    private IHealth _health;

    private Action OnFartHandeler => () => SetAnimatorTrigger("Attack");
    private Action OnReloadHandeler => () => SetAnimatorTrigger("Reload");
    private Action OnDieHandeler => () => SetAnimatorTrigger("Die");
    private Action<float> OnSpeedUpdateHandeler => (speed) => SetAnimatorFloat("WalkSpeed", speed);
    
    public void Init(IFarter fartBehaviour, ISpeedReader speedReader, IHealth health)
    {
        _fartBehaviour = fartBehaviour;
        _speedReader = speedReader;
        _health = health;

        _fartBehaviour.OnFart += OnFartHandeler;
        _fartBehaviour.OnReload += OnReloadHandeler;
        _speedReader.OnSpeedUpdated += OnSpeedUpdateHandeler;
        _health.OnDeath += OnDieHandeler;
    }

    private void OnDestroy()
    {
        _fartBehaviour.OnFart -= OnFartHandeler;
        _fartBehaviour.OnReload -= OnReloadHandeler;
        _speedReader.OnSpeedUpdated -= OnSpeedUpdateHandeler;
        _health.OnDeath -= OnDieHandeler;

    }

    private void SetAnimatorTrigger(string key) => _animator.SetTrigger(key);
    private void SetAnimatorFloat(string key, float value) => _animator.SetFloat(key, value);
}
