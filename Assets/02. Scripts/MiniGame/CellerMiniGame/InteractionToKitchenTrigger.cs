using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionToKitchenTrigger : InteractionObject
{
    public override void EnterInteraction()
    {
        GameManager.Inst.UI.ActiveTextPanal("���� ����ִ�. \n ���踦 ã�ƺ���.");
    }
}
