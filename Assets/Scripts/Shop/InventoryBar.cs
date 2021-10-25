using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryBar : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttons = new List<GameObject>();

    [SerializeField] private InventorySO playerInventory;

    [SerializeField] private Sprite emptyIcon;

    private void OnEnable()
    {
        playerInventory.OnValueChanged += UpdateInventoryBar;
    }

    private void OnDisable()
    {
        playerInventory.OnValueChanged -= UpdateInventoryBar;
    }

    private void Start()
    {
        UpdateInventoryBar();
    }

    private void UpdateInventoryBar()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            if(playerInventory.Inventory[i] != null)
            {
                buttons[i].GetComponentInChildren<Image>().sprite = playerInventory.Inventory[i].ItemIcon;
                buttons[i].GetComponentInChildren <TMP_Text>().text = playerInventory.Inventory[i].Name;
            }
            else
            {
                buttons[i].GetComponentInChildren<Image>().sprite = emptyIcon;
                buttons[i].GetComponentInChildren<TMP_Text>().text = "Empty";
            }
        }
    }
}
