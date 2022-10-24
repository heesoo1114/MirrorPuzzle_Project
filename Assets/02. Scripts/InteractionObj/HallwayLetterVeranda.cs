using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayLetterVeranda : InteractionObject
{
    public override void InteractionEvent()
    {
        InventorySystem.Inst.AddItem("HALLWAY_LETTER_VERANDA");
        gameObject.SetActive(false);
    }
}
