using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryButtonUpdate : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttons = new List<GameObject>();

    [SerializeField] private InventorySO playerInventory;

    [SerializeField] private Sprite emptyIcon;

    [SerializeField] private ShopManager shopManager;

    private void OnEnable()
    {
        playerInventory.OnValueChanged += UpdateInventoryButtons;
        shopManager.OnUiUpdateNeeded += ToggleUpgradeButton;
    }

    private void OnDisable()
    {
        playerInventory.OnValueChanged -= UpdateInventoryButtons;
        shopManager.OnUiUpdateNeeded -= ToggleUpgradeButton;
    }

    private void Start()
    {
        UpdateInventoryButtons();
    }

    private void UpdateInventoryButtons()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            var playerinventory = playerInventory.Inventory[i];
            var inventoryButton = buttons[i].GetComponent<InventoryPanelButton>();

            if (playerinventory != null)
            {
                inventoryButton.SetButton(playerinventory.ItemIcon, playerinventory.Name);
            }
            else
            {
                inventoryButton.SetButton(emptyIcon, "Empty");
            }
        }
    }

    public void ToggleUpgradeButton()
    {
        if (shopManager.ActiveShopItem == null || !shopManager.ActiveShopItem.Upgradeable)
        {
            shopManager.UpgradeItemButton.gameObject.SetActive(false);
        }
        else
        {
            shopManager.UpgradeItemButton.gameObject.SetActive(true);
        }
    }
}
