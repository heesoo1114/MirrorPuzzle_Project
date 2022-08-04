using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionHandMirror : InteractionObject
{
    public override void InteractionEvent()
    {
        InventorySystem.Inst.AddItem("HAND_MIRROR");
        Destroy(gameObject);
    }
}