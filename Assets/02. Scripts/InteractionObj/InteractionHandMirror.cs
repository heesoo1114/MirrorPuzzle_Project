using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandMirror : InteractionObject
{
    public override void InteractionEvent()
    {
        GameManager.Inst.UI.ActiveTextPanal("�հſ��� ȹ���ߴ�");
        InventorySystem.Inst.AddItem("HAND_MIRROR");

        GameManager.Inst.UI.UnShowInteractionUI();
        Destroy(gameObject,1f);
    }
}