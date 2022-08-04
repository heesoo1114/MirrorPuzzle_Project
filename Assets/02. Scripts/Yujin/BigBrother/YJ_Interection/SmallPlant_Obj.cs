using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPlant_Obj : InteractionObject
{
    private bool _getItem;
    public override void InteractionEvent()
    {
        if (_getItem) return;
        _getItem = true;
        base.InteractionEvent();

        InventorySystem.Inst.AddItem("BB_BlueBullet",3);
    }

}

