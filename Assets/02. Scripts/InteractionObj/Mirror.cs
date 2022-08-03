using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : InteractionObject
{
    public override void InteractionEvent()
    {
        GameManager.Inst.ChangeWorld();
    }
}
