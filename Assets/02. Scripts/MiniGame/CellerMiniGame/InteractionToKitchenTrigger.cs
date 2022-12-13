using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionToKitchenTrigger : InteractionObject
{
    public override void EnterInteraction()
    {
        if (InventorySystem.Inst.equipItemDataID == "10") return;
        TextSystem.Inst.ActiveTextPanal("문이 잠겨있다. \n 열쇠를 찾아보자.");
    }

    public override void InteractionEvent()
    {
        if (InventorySystem.Inst.equipItemDataID == "10")
        {
            TextSystem.Inst.ActiveTextPanal("문이 열렸다.");
            InventorySystem.Inst.UseEquipItem();
            StartCoroutine(ImmediatelyStop());
        }
    }

    IEnumerator ImmediatelyStop()
    {
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }
}
