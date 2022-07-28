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
            Debug.Log("인벤");
            GameManager.Inst.UI.ActiveTextPanal("문이 열렸다.");
            this.gameObject.SetActive(false);
        }
    }

    public override void EnterInteraction()
    {
        GameManager.Inst.UI.ActiveTextPanal("문이 잠겨있다. \n 열쇠를 찾아보자.");
    }
}
