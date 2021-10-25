using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{

    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemCost;
    [SerializeField] private Image itemImage;

    public ItemSO Item { get; private set; }

    public void SetUpShopItem(ItemSO item)
    {
        Item = item;

        itemName.text = Item.Name;
        itemCost.text = $"Cost: {Item.Cost}";
        itemImage.sprite = Item.ItemIcon;
    }
}
