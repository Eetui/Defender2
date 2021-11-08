using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthbar : MonoBehaviour
{
    private FloatSO _maxHealth;
    private FloatSO _health;

    [SerializeField] private Image _image;

    private void Awake()
    {
        UnitHealth unitHealth = GetComponentInParent<UnitHealth>();
        _maxHealth = unitHealth.MaxHealthSO;
        _health = unitHealth.HealthSO;

        _health.OnValueChanged += UpdateHealthbar;
    }

    private void OnDestroy()
    {
        _health.OnValueChanged -= UpdateHealthbar;
    }

    private void UpdateHealthbar()
    {
        _image.fillAmount = Mathf.Clamp01(_health.Value/_maxHealth.Value);
    }
}
