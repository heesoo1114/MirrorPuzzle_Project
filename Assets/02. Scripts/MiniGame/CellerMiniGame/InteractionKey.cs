using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionKey : InteractionObject
{
    public UnityEvent GetKeyEvent;

    public override void InteractionEvent()
    {
        GetKeyEvent?.Invoke();
        InventorySystem.Inst.AddItem("10");

        CutSceneManager.Inst.StartCutScene("INVENTORY");
        Destroy(gameObject);
    }
}
