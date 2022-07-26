using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemData
{
    public string name;
    [TextArea(5, 10)] public string info;
    [Space]
    public Sprite sprite;

    public ItemData(ItemData data)
    {
        name = data.name;
        info = data.info;
    }

    public ItemData(string name, string info, Sprite sprite)
    {
        this.name = name;
        this.info = info;
        this.sprite = sprite;
    }
}

[System.Serializable]
public class InventoryItemData
{
    public ItemData itemData;
    public int itemCount;

    public InventoryItemData(InventoryItemData data)
    {
        itemData = data.itemData;
        itemCount = data.itemCount;
    }

    public InventoryItemData(ItemData data, int cnt)
    {
        itemData = data;
        itemCount = cnt;
    }

    public InventoryItemData(string name, string info, int cnt)
    {
        itemData = new ItemData(name, info, null);
        itemCount = cnt;
    }
}


[CreateAssetMenu(menuName ="SO/Item/ItemSO")]
public class ItemSO : ScriptableObject
{
    public List<ItemData> itemDataList;
}
