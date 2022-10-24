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

        TextSystem.Inst.ActiveTextPanal("���� ������ �ʴ´�.\n�ٸ� ���迡�� �ѹ� Ȯ���غ���!");
    }
}
