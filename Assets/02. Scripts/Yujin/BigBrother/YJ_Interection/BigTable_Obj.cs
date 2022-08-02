using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTable_Obj : InteractionObject
{
    public override void InteractionEvent()
    {
        base.InteractionEvent();

        InventorySystem.Inst.AddItem("BB_RedBullet");
    }
}
