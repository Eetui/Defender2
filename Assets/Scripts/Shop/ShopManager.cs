using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private InputActionsSO _input;

    [Header("Player")]
    [SerializeField] private FloatSO _playerMoney;
    [SerializeField] private InventorySO _playerInventory;

    [Header("Shop")]
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private InventorySO _shopInventory;
    [SerializeField] private GameObject _shopContent;
    [SerializeField] private GameObject _shopItemPrefab;


    [Header("Buttons")]
    [SerializeField] private Button _sellItemButton;
    [SerializeField] private Button _upgradeItemButton;

    private ItemSO _activeShopItem;
    private int _activeShopItemIndex;

    public Button UpgradeItemButton => _upgradeItemButton;
    public ItemSO ActiveShopItem => _activeShopItem;

    public UnityAction OnUiUpdateNeeded = delegate { };

    private void OnEnable()
    {
        _input.OnShopCloseEvent += CloseShop;
        _input.OnShopOpenEvent += ShopToggle;

        _sellItemButton.onClick.AddListener(() => SellItem(_activeShopItem));
        _upgradeItemButton.onClick.AddListener(() => BuyUpgrade(ActiveShopItem));
    }

    private void OnDisable()
    {
        _input.OnShopCloseEvent -= CloseShop;
        _input.OnShopOpenEvent -= ShopToggle;

        _sellItemButton.onClick.RemoveAllListeners();
        _upgradeItemButton.onClick.RemoveAllListeners();
    }

    private void Awake()
    {
        SetUpShop();
    }

    private void Start()
    {
        SetActiveShopItem(0);
    }

    private void SetActiveShopItemIndex(int value) => _activeShopItemIndex = value;

    public int GetActiveShopItemIndex() => _activeShopItemIndex;

    public void SetUpShop()
    {
        foreach (var item in _shopInventory.Inventory)
        {
            var shopObject = Instantiate(_shopItemPrefab, _shopContent.transform);
            var shopItem = shopObject.GetComponent<ShopItem>();
            shopItem.SetUpShopItem(item);

            var shopObjectButton = shopObject.GetComponentInChildren<Button>();
            shopObjectButton.onClick.AddListener(() => BuyItem(item));
        }
    }

    public void BuyItem(ItemSO item)
    {
        if (_playerInventory.Inventory.Contains(item) && item.Stackable)
        {
            if (_playerMoney.Value >= item.Cost)
            {
                item.AddStack();
                _playerMoney.ApplyChange(-item.Cost);
                OnUiUpdateNeeded.Invoke();
            }
        }
        else if (!_playerInventory.Inventory.Contains(item))
        {
            int addedIndex = 0;

            if (_playerMoney.Value >= item.Cost)
            {
                if (_playerInventory.AddItem(item, out addedIndex))
                {
                    _playerMoney.ApplyChange(-item.Cost);
                    SetActiveShopItem(addedIndex);
                    OnUiUpdateNeeded.Invoke();
                }
                else
                {
                    Debug.LogWarning("No empty slots for new items");
                }
            }
            else
            {
                Debug.LogWarning("Not enough money");
            }
        }
    }

    public void BuyUpgrade(ItemSO item)
    {
        if (item is GunSO gun)
        {
            if (_playerMoney.Value >= gun.UpgradeCost)
            {
                _playerMoney.ApplyChange(-gun.UpgradeCost);
                gun.LevelUp();
                OnUiUpdateNeeded.Invoke();
            }
        }
    }

    public void SellItem(ItemSO item)
    {
        if (item == null) return;

        if (item.Stackable && item.Stack > 1)
        {
            _playerMoney.ApplyChange(item.SellAmount);
            item.RemoveStack();
            SetActiveShopItem(GetActiveShopItemIndex());
            return;
        }
        else if (_playerInventory.RemoveItem(item))
        {
            if (item is GunSO gun)
            {
                _playerMoney.ApplyChange(gun.SellAmount);
                gun.Reset();
            }
            else
            {
                _playerMoney.ApplyChange(item.SellAmount);
                item.ResetStacks();
            }

            SetActiveShopItem(GetActiveShopItemIndex());
        }
    }

    public void SetActiveShopItem(int slot)
    {
        _activeShopItem = _playerInventory.Inventory[slot];
        SetActiveShopItemIndex(slot);
        OnUiUpdateNeeded.Invoke();
    }

    private void CloseShop()
    {
        if (_shopPanel.activeInHierarchy)
        {
            _shopPanel.SetActive(false);
            _input.EnablePauseInput();
            _input.EnableGameplayInput();
            return;
        }
    }

    public void ShopToggle()
    {
        if (_shopPanel.activeInHierarchy)
        {
            _shopPanel.SetActive(false);
            _input.EnablePauseInput();
            _input.EnableGameplayInput();
            return;
        }

        if (!_shopPanel.activeInHierarchy)
        {
            _shopPanel.SetActive(true);
            _input.DisablePauseInput();
            _input.DisableGameplayInput();
            return;
        }
    }
}
