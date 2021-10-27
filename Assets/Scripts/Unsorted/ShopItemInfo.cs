using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemInfo : MonoBehaviour
{
    [SerializeField] private GameObject shopItemInfoPanel;
    [SerializeField] private ShopManager shopManager;

    [Header("General")]
    [SerializeField] private Image itemImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text stacksText;
    [SerializeField] private TMP_Text sellForText;
    [SerializeField] private TMP_Text description;


    private void OnEnable()
    {
        shopManager.OnUiUpdateNeeded += UpdateInfo;
    }

    private void OnDisable()
    {
        shopManager.OnUiUpdateNeeded -= UpdateInfo;
    }

    private void Start()
    {
        UpdateInfo();
    }

    private void UpdateInfo()
    {
        var item = shopManager.ActiveShopItem;

        if (item != null && item.GetType() != typeof(GunSO))
        {
            shopItemInfoPanel.SetActive(true);

            itemImage.sprite = item.ItemIcon;
            nameText.text = item.Name;
            stacksText.text = $"Stacks: {item.Stack}";
            sellForText.text = $"Sell for: {item.SellAmount}";
            description.text = $"{item.Description}";

        }
        else
        {
            shopItemInfoPanel.SetActive(false);
        }

    }
}
