using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandMirror : InteractionObject
{
    public override void InteractionEvent()
    {
        gameObject.SetActive(false);
        TextSystem.Inst.ActiveTextPanal("º’∞≈øÔ¿ª »πµÊ«ﬂ¥Ÿ");
        InventorySystem.Inst.AddItem("HAND_MIRROR");

        Destroy(gameObject,1f);
    }
}