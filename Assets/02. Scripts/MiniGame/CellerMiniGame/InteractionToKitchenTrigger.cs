using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionToKitchenTrigger : InteractionObject
{
    public override void InteractionEvent()
    {
        Debug.Log(InventorySystem.Inst.equipItemData.itemID);
        if (InventorySystem.Inst.equipItemData.itemID == "10")
        {
            Debug.Log("�κ�");
            GameManager.Inst.UI.ActiveTextPanal("���� ���ȴ�.");
            this.gameObject.SetActive(false);
        }
    }

    public override void EnterInteraction()
    {
        GameManager.Inst.UI.ActiveTextPanal("���� ����ִ�. \n ���踦 ã�ƺ���.");
    }
}
