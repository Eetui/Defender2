using System.Collections.Generic;
using UnityEngine;

public class ShopSelectedInventoryItemUI : MonoBehaviour
{
    [SerializeField] private ShopManager shopManager;
    [SerializeField] private List<Transform> buttons = new List<Transform>();
    [SerializeField] private Transform selectImage;

    private void OnEnable()
    {
        shopManager.OnUiUpdateNeeded += ChangeSelectedImage;
    }

    private void OnDisable()
    {
        shopManager.OnUiUpdateNeeded += ChangeSelectedImage;
    }

    private void Start()
    {
        ChangeSelectedImage();
    }

    private void ChangeSelectedImage()
    {
        selectImage.position = buttons[shopManager.GetActiveShopItemIndex()].position;
    }
}
