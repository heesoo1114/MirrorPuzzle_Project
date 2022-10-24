using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLibrary : InteractionObject
{
    public override void EnterInteraction()
    {
        if (GameManager.Inst.WorldType == WorldType.MirrorWorld)
        {
            gameObject.SetActive(false);
        }
    }

    public override void InteractionEvent()
    {
        if (GameManager.Inst.WorldType == WorldType.MirrorWorld) return;

        TextSystem.Inst.ActiveTextPanal("문이 열리지 않는다.\n다른 세계에서 한번 확인해보자!");
    }
}
