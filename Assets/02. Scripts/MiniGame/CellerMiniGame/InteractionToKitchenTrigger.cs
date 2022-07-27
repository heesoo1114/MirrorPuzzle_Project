using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionToKitchenTrigger : InteractionObject
{
    public override void EnterInteraction()
    {
        GameManager.Inst.UI.ActiveTextPanal("문이 잠겨있다. \n 열쇠를 찾아보자.");
    }
}
