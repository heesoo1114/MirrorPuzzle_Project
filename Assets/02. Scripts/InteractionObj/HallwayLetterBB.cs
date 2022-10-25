using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayLetterBB : InteractionObject
{
    public override void InteractionEvent()
    {
        InventorySystem.Inst.AddItem("HALLWAY_LETTER_BB");
        gameObject.SetActive(false);
    }
}
