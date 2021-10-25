using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryPanelButton : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image icon;

    public void SetButton(Sprite iconSprite, string itemName)
    {
        icon.sprite = iconSprite;
        nameText.text = itemName;
    }
}
