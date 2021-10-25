using UnityEngine;

[CreateAssetMenu(fileName = "Unit Stats", menuName = "ScriptableObjects/Stats/Unit Stats")]
public class UnitStats : ScriptableObject
{
    [SerializeField] private protected string _name;
    [SerializeField] private protected Sprite _icon;
    [SerializeField] private protected float _maxHealth;
    [SerializeField] private protected float _speed;

    public string Name => _name;
    public Sprite Icon => _icon;
    public float MaxHealth => _maxHealth;
    public float Speed => _speed;
}
