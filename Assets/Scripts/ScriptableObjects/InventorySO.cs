using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory")]
public class InventorySO : ScriptableObject
{
    [HideInInspector] public List<ItemSO> Inventory { get { return _currentInventory; } }

    [SerializeField]
    private List<ItemSO> _inventory = new List<ItemSO>(3);
    private List<ItemSO> _currentInventory = new List<ItemSO>(3);


    [SerializeField] private bool _resetOnEnable;

    public event UnityAction OnValueChanged = delegate { };
    public event UnityAction OnEmptyInventory = delegate { };

    private void OnEnable()
    {
        if (_resetOnEnable)
        {
            Reset();
        }
    }

    public void Reset()
    {

        foreach (var item in _inventory)
        {
            if(item != null)
                item.Reset();
            if (item is GunSO gun)
                gun.Reset();
        }

        _currentInventory.Clear();

        for (int i = 0; i < _inventory.Count; i++)
        {
            _currentInventory.Add(_inventory[i]);
        }

        OnValueChanged?.Invoke();
    }

    public bool Add(ItemSO item, out int index) //out index so we can get what was the most recent item
    {
        for (int i = 0; i < _currentInventory.Count; i++)
        {
            if (_currentInventory[i] == null)
            {
                _currentInventory[i] = item;
                OnValueChanged?.Invoke();
                index = i;
                return true;
            }
        }

        index = -1;
        return false;
    }

    public void Remove(int itemSlot)
    {
        _currentInventory[itemSlot] = null;
        OnValueChanged?.Invoke();
        CheckForEmptySpace();
    }

    public bool Remove(ItemSO item)
    {
        if (item == null) return false; 

        int index = _currentInventory.FindIndex(a => a == item);

        if (index != -1)
        {
            _currentInventory[index] = null;
            OnValueChanged?.Invoke();
            CheckForEmptySpace();
            return true;
        }

        return false;
    }

    private void CheckForEmptySpace()
    {
        foreach (var item in Inventory)
        {
            if (item != null)
            {
                return;
            }
        }

        OnEmptyInventory?.Invoke();
    }
}
