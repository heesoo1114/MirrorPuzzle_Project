using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwayLetterLibrary : InteractionObject
{
    public override void InteractionEvent()
    {
        InventorySystem.Inst.AddItem("HALLWAY_LETTER_LIBRARY");
        gameObject.SetActive(false);
    }
}
