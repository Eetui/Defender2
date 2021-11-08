using System;
using UnityEngine;

public class ChangePlayerHandSprite : MonoBehaviour
{
    [SerializeField] private Sprite emptyHandSprite;

    private Player player;
    private SpriteRenderer handSprite;

    private void Awake()
    {
        player = GetComponentInParent<Player>();
        handSprite = GetComponent<SpriteRenderer>();
    }

    private void OnEnable() => player.OnActiveItemChanged += ChangeHandSprite;

    private void OnDisable() => player.OnActiveItemChanged -= ChangeHandSprite;

    private void ChangeHandSprite()
    {
        if(player.CurrentItem != null)
        {
            handSprite.sprite = player.CurrentItem.ItemIcon;
            return;
        }

        handSprite.sprite = emptyHandSprite;
    }
}
