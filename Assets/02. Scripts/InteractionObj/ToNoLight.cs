using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNoLight : InteractionObject
{
    // ó���� �ֹ濡�� �� ���������� �̵��� �� �������� ���� �ڵ�

    public override void EnterInteraction()
    {
        GameManager.Inst.UI.ActiveTextPanal("���� ���� �ִ�. \n ���� �� �� �̵�����.");
    }
}
