using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour
{
    public float Health => _health.Value;
    public FloatSO HealthSO => _health;
    public FloatSO MaxHealthSO => _maxHealth;

    public UnityEvent OnDie;
    public UnityEvent OnTakeDamage;
    public UnityEvent OnHeal;

    [SerializeField] private FloatSO _maxHealth;
    [SerializeField] private FloatSO _health;


    private void Awake()
    {
        if (_maxHealth == null)
        {
            _maxHealth = ScriptableObject.CreateInstance<FloatSO>();
        }

        if (_health == null)
        {
            _health = ScriptableObject.CreateInstance<FloatSO>();
        }
    }
    private void OnEnable()
    {
        InitHealth();
    }

    private void InitHealth()
    {
        if (_health != null) _health.SetValue(_maxHealth.Value);
    }
    public void Init(float maxHealth)
    {
        _maxHealth.SetValue(maxHealth);
        _health.SetValue(_maxHealth.Value);
    }

    public void SetMaxHealth(float value) => _maxHealth.SetValue(value);

    public void Heal(float value)
    {
        _health.ApplyChange(value);

        if (_health.Value > _maxHealth.Value)
        {
            _health.SetValue(_maxHealth.Value);
        }

        OnHeal.Invoke();
    }

    public void TakeDamage(float value)
    {
        _health.ApplyChange(-value);

        if (_health.Value <= 0)
        {
            OnDie.Invoke();
            return;
        }

        OnTakeDamage.Invoke();
    }
}
