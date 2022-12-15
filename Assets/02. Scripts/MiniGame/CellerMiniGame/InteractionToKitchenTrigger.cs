using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionToKitchenTrigger : InteractionObject
{
    public override void EnterInteraction()
    {
        if (InventorySystem.Inst.equipItemDataID == "10") return;
        TextSystem.Inst.ActiveTextPanal("���� ����ִ�. \n ���踦 ã�ƺ���.");
    }

    public override void InteractionEvent()
    {
        if (InventorySystem.Inst.equipItemDataID == "10")
        {
            TextSystem.Inst.ActiveTextPanal("���� ���ȴ�.");
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
