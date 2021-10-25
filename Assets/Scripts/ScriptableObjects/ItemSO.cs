using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Items/Item")]
public class ItemSO : ScriptableObject
{
    [SerializeField] private protected string _name;
    [SerializeField] private protected Sprite _itemIcon;
    [SerializeField] private protected float _cost;
    [SerializeField] private protected bool _stackable = false;
    [SerializeField] private protected int _stack = 1;
    [SerializeField] private protected bool _upgradeable;
    [SerializeField] private protected string _description;

    #region Properties

    public string Name => _name;
    public Sprite ItemIcon => _itemIcon;
    public float Cost => _cost;
    public bool Stackable => _stackable;
    public virtual float SellAmount => _cost / 2;
    public bool Upgradeable => _upgradeable;
    public int Stack => _stack;
    public string Description => _description;

    #endregion

    private void OnEnable()
    {
        Reset();
    }

    public void AddStack()
    {
        _stack++;
    }

    public void RemoveStack()
    {
        _stack--;
    }

    public virtual void ResetStacks()
    {
        _stack = 1;
    }

    public virtual void Reset()
    {
        ResetStacks();
    }
}
