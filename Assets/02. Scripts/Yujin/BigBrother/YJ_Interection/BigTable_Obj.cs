using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigTable_Obj : InteractionObject
{
    private bool _getItem;
    public override void InteractionEvent()
    {
        if (_getItem) return;
        _getItem = true;
        base.InteractionEvent();

        InventorySystem.Inst.AddItem("BB_RedBullet", 3);
    }
}
