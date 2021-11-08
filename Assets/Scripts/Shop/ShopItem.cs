using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private Image _image;

    public ItemSO Item { get; private set; }

    public void SetUpShopItem(ItemSO item)
    {
        Item = item;

        _name.text = Item.Name;
        _cost.text = $"Cost: {Item.Cost}";
        _image.sprite = Item.ItemIcon;
    }
}
