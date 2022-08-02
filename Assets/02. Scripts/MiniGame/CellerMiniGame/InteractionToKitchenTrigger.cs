using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionToKitchenTrigger : InteractionObject
{
    public override void InteractionEvent()
    {
        if (InventorySystem.Inst.equipItemData.itemID == "10")
        {
            GameManager.Inst.UI.ActiveTextPanal("문이 열렸다.");
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
        GameManager.Inst.UI.ActiveTextPanal("문이 잠겨있다. \n 열쇠를 찾아보자.");
    }
}
