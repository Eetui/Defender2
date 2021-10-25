using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Float", menuName = "ScriptableObjects/Variables/Float")]
public class FloatSO : ScriptableObject
{
    [SerializeField] private float value;
    
    private float currentValue;
    public float Value
    {
        get { return currentValue; }
    }

    public event UnityAction OnValueChanged = delegate { };

    private void OnEnable()
    {
        Reset();
    }

    public void ApplyChange(float value)
    {
        currentValue += value;
        OnValueChanged?.Invoke();
    }

    public void SetValue(float value)
    {
        currentValue = value;
        OnValueChanged?.Invoke();
    }

    public void Reset()
    {
        SetValue(value);
    }
}
