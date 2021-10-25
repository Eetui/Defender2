using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory")]
public class InventorySO : ScriptableObject
{
    [HideInInspector] public List<ItemSO> Inventory { get { return currentInventory; } }

    [SerializeField]
    private List<ItemSO> _inventory = new List<ItemSO>(3);
    private List<ItemSO> currentInventory = new List<ItemSO>(3);


    [SerializeField] private bool resetInventoryOnEnable;

    public event UnityAction OnValueChanged = delegate { };
    public event UnityAction OnEmptyInventory = delegate { };

    private void OnEnable()
    {
        if (resetInventoryOnEnable)
        {
            ResetInventory();
        }
    }

    public void ResetInventory()
    {

        foreach (var item in _inventory)
        {
            if(item != null)
                item.Reset();
            if (item is GunSO gun)
                gun.Reset();
        }

        currentInventory.Clear();

        for (int i = 0; i < _inventory.Count; i++)
        {
            currentInventory.Add(_inventory[i]);
        }

        OnValueChanged?.Invoke();
    }

    public bool AddItem(ItemSO item, out int index) //out index so we can get what was the most recent item
    {
        for (int i = 0; i < currentInventory.Count; i++)
        {
            if (currentInventory[i] == null)
            {
                currentInventory[i] = item;
                OnValueChanged?.Invoke();
                index = i;
                return true;
            }
        }

        index = -1;
        return false;
    }

    public void RemoveItem(int itemSlot)
    {
        currentInventory[itemSlot] = null;
        OnValueChanged?.Invoke();
        CheckForEmptyInventory();
    }

    public bool RemoveItem(ItemSO item)
    {
        if (item == null) return false; 

        int index = currentInventory.FindIndex(a => a == item);

        if (index != -1)
        {
            currentInventory[index] = null;
            OnValueChanged?.Invoke();
            CheckForEmptyInventory();
            return true;
        }
        else
        {
            Debug.Log("No items removed");
            return false;
        }
    }

    private void CheckForEmptyInventory()
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
