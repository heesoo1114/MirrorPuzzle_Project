using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionBrotherNote : InteractionObject
{
    public UnityEvent GetNoteEvent;

    public override void InteractionEvent()
    {
        GetNoteEvent?.Invoke();
        InventorySystem.Inst.AddItem("20");
        Destroy(gameObject);
    }
}
