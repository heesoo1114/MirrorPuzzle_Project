using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCellar : InteractionObject
{
    public override void EnterInteraction()
    {
        GameManager.Inst.UI.ActiveTextPanal("���ϽǷ� ���� ���̴�. \n ���� �� �� ���°� ����.");
    }

    public override void InteractionEvent()
    {
    }

}
