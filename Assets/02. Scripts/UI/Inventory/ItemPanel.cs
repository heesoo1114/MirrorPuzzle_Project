using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemPanel : MonoBehaviour
{
    private InventoryItemData _inventoryItemData;
    private Image _frameImage;
    private Image _itemImage;

    private int _currentIndex;

    public int Index => _currentIndex;

    public bool IsEmpty => _inventoryItemData == null;

    public string ItemName => _inventoryItemData.itemData.name;
    public string ItemInfo => _inventoryItemData.itemData.info;
    public InventoryItemData ItemData => _inventoryItemData;

    private void Awake()
    {
        _frameImage = GetComponent<Image>();
    }

    public void Init(InventoryItemData data)
    {
        if(_frameImage == null)
            _frameImage = GetComponent<Image>();
        if (_itemImage == null)
            _itemImage = transform.Find("ItemImage").GetComponent<Image>();

        _inventoryItemData = data;
        _itemImage.sprite = _inventoryItemData.itemData.sprite;
        _currentIndex = transform.GetSiblingIndex() - 1;
    }

    public void SetSprite(Sprite sprite)
    {
        _frameImage.sprite = sprite;
    }
}
