using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionToKitchenTrigger : InteractionObject
{
    public override void InteractionEvent()
    {
        if (InventorySystem.Inst.equipItemDataID == "10")
        {
            GameManager.Inst.UI.ActiveTextPanal("���� ���ȴ�.");
            InventorySystem.Inst.UseEquipItem();
            StartCoroutine(ImmediatelyStop());
        }

        else
        {
            GameManager.Inst.UI.ActiveTextPanal("���� ����ִ�. \n ���踦 ã�ƺ���.");
        }
    }

    IEnumerator ImmediatelyStop()
    {
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }

}
