using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLivingRoom : InteractionObject
{
    public override void EnterInteraction()
    {
        TextSystem.Inst.ActiveTextPanal("2������ ���� ���� ã�ƺ���! \n 1������ ������ ������ ���� �� ����.");
    }
}
