using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandMirror : InteractionObject
{
    public override void InteractionEvent()
    {
        TextSystem.Inst.ActiveTextPanal("�հſ��� ȹ���ߴ�");
        InventorySystem.Inst.AddItem("HAND_MIRROR");

        InteractionImage.UnShow();
        Destroy(gameObject,1f);
    }
}