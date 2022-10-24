using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayLetterBedroom : InteractionObject
{
    public override void InteractionEvent()
    {
        InventorySystem.Inst.AddItem("HALLWAY_LETTER_BEDROOM");
        gameObject.SetActive(false);
    }
}
