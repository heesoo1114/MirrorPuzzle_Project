using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayLetterSB : InteractionObject
{
    public override void InteractionEvent()
    {
        InventorySystem.Inst.AddItem("HALLWAY_LETTER_SB");
        gameObject.SetActive(false);
    }
}
