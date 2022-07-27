using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGameObject : InteractionObject
{
    public override void InteractionEvent()
    {
        GameManager.Inst.UI.StartLightLineGame();
    }
}
