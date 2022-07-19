using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ItemData
{
    public string itemID;

    public string name;
    [TextArea(5, 10)] public string info;
    [Space]
    public Sprite sprite;


    public ItemData(ItemData data)
    {
        itemID = data.itemID;
        name = data.name;
        info = data.info;
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
}


[CreateAssetMenu(menuName ="SO/Item/ItemSO")]
public class ItemSO : ScriptableObject
{
    public List<ItemData> itemDataList;
}
