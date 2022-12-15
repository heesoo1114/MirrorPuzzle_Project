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
        else
        {
            TextSystem.Inst.ActiveTextPanal("���� ������ �ʴ´�.\n�ٸ� ���迡�� �ѹ� Ȯ���غ���!");
        }
    }
}
