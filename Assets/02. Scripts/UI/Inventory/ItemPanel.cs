using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemPanel : MonoBehaviour
{
    private InventoryItemData _inventoryItemData;
    private Image _itemImage;

    public bool IsEmpty => _inventoryItemData == null;

    public string ItemName => _inventoryItemData.itemData.name;
    public string ItemInfo => _inventoryItemData.itemData.info;

    private void Awake()
    {
        _itemImage = GetComponent<Image>();
    }

    public void Init(InventoryItemData data)
    {
        if(_itemImage == null)
            _itemImage = GetComponent<Image>();

        _inventoryItemData = data;
    }

    public void SetSprite(Sprite sprite)
    {
        _itemImage.sprite = sprite;
    }
}
