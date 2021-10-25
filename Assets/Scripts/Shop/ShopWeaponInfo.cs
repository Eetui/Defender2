using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ShopWeaponInfo : MonoBehaviour
{
    [SerializeField] private GameObject shopWeaponInfoPanel;
    [SerializeField] private ShopManager shopManager;

    [Header("General")]
    [SerializeField] private Image weaponImage;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text sellForText;

    [Header("Current Level Texts")]
    [SerializeField] private TMP_Text currentDamageText;
    [SerializeField] private TMP_Text currentFireRateText;
    [SerializeField] private TMP_Text currentUpgradeCostText;

    [Header("Next Level Texts")]
    [SerializeField] private TMP_Text nextDamageText;
    [SerializeField] private TMP_Text nextFireRateText;
    [SerializeField] private TMP_Text nextUpgradeCostText;

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
        var gun = shopManager.ActiveShopItem as GunSO;

        if (gun != null)
        {
            shopWeaponInfoPanel.SetActive(true);

            weaponImage.sprite = gun.ItemIcon;
            nameText.text = $"{gun.Name}";
            levelText.text = $"Level: {gun.Level + 1}";
            sellForText.text = $"Sell for: {gun.SellAmount}";
            currentDamageText.text = $"Damage: {gun.Damage}";
            currentFireRateText.text = $"Fire Rate: {gun.FireRate}";
            currentUpgradeCostText.text = $"Upgrade Cost: {gun.UpgradeCost}";
            nextDamageText.text = $"Damage: {gun.Damage + gun.DamageGrowth}";
            nextFireRateText.text = $"Fire Rate: {gun.FireRate + gun.FireRateGrowth}";
            nextUpgradeCostText.text = $"Upgrade Cost: {gun.UpgradeCost + gun.BaseUpgradeCost}";
        }
        else
        {
            shopWeaponInfoPanel.SetActive(false);
        }

    }
}
