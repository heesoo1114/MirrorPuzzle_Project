using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : InteractionObject
{
    public override void InteractionEvent()
    {
        if (InventorySystem.Inst.equipItemDataID == "HAND_MIRROR") return;
        GameManager.Inst.ChangeWorld();
    }
}
