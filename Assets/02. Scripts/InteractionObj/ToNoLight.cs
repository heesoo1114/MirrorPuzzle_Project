using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNoLight : InteractionObject
{
    // ó���� �ֹ濡�� �� ���������� �̵��� �� �������� ���� �ڵ�

    public override void EnterInteraction()
    {
        TextSystem.Inst.ActiveTextPanal("���� ���� �ִ�. \n ���� �� �� �̵�����.");
    }
}
