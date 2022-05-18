using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : InteractionObject
{
    public override void InteractionEvent()
    {
        GameManager.Inst.UI.StartMiniGame();
    }
}
