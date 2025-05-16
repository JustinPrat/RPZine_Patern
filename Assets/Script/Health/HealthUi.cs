using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour
{
    private IHealth _health;

    [SerializeField] private Slider _slider;
    [SerializeField] private float _sliderFillSpeed;
    private bool _isSliderValueChanging;

    public void Init(IHealth iHealth)
    {
        _health = iHealth;

        _slider.maxValue = _health.MaxHealth;
        iHealth.OnTakeDamage += UpdateSlider;
        iHealth.OnHeal += UpdateSlider;
        
        UpdateSlider();
    }


    public void ComputeUpdate()
    {
        ComputeSliderValue();
    }

    private void ComputeSliderValue()
    {
        if(!_isSliderValueChanging)
            return;

        if (Math.Abs(_slider.value - _health.Health) > .1f)
        {
            _slider.value = Mathf.Lerp(_slider.value, _health.Health, Time.deltaTime * _sliderFillSpeed);
        }
        else
        {
            _isSliderValueChanging = false;
        }
    }
    private void UpdateSlider()
    {
        _isSliderValueChanging = true;
    }

    private void OnDestroy()
    {
        _health.OnTakeDamage -= UpdateSlider;
        _health.OnHeal -= UpdateSlider;
    }
}

