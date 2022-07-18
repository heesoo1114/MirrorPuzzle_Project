using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateItemPanel : MonoBehaviour
{
    [SerializeField] private ItemPanel _itemPanelTemp;
    [SerializeField] private int _defaultGenerateCnt = 5;

    public List<ItemPanel> GeneratePanel()
    {
        var list = DataManager.Inst.CurrentPlayer.inventoryList;
        List<ItemPanel> panelList = new List<ItemPanel>();

        int cnt = list.Count < _defaultGenerateCnt ? _defaultGenerateCnt : list.Count;
        for (int i = 0; i < cnt; i++)
        {
            ItemPanel panel = null;
            if ( i < list.Count )
            {
               panel = AddPanel(list[i]);
            }

            else
            {
                panel = AddPanel(null);
            }

            panelList.Add(panel);
        }

        return panelList;
    }

    public ItemPanel AddPanel(InventoryItemData data)
    {
        ItemPanel panel = Instantiate(_itemPanelTemp, _itemPanelTemp.transform.parent);

        panel.Init(data);
        panel.gameObject.SetActive(true);
        return panel;
    }
}
