using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionToKitchenTrigger : InteractionObject
{
    public override void InteractionEvent()
    {
        if (InventorySystem.Inst.equipItemData.itemID == "10")
        {
            GameManager.Inst.UI.ActiveTextPanal("���� ���ȴ�.");
            StartCoroutine(ImmediatelyStop());
        }
    }

    IEnumerator ImmediatelyStop()
    {

        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }

    public override void EnterInteraction()
    {
        GameManager.Inst.UI.ActiveTextPanal("���� ����ִ�. \n ���踦 ã�ƺ���.");
    }
}
