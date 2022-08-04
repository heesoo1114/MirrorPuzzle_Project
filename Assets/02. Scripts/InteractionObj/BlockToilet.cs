using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockToilet : InteractionObject
{
    public override void EnterInteraction()
    {
        if (GameManager.Inst.WorldType == WorldType.RealWorld)
        {
            gameObject.SetActive(false);
        }
    }

    public override void InteractionEvent()
    {
        if (GameManager.Inst.WorldType == WorldType.RealWorld) return;

        GameManager.Inst.UI.ActiveTextPanal("문이 열리지 않는다.\n다른 세계에서 한번 확인해보자!");
    }

}
