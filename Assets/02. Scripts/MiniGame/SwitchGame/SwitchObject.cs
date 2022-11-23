using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchObject : InteractionObject
{
    // ����� 1 �Ǵ� 2�� ����
    [Header("1�Ǵ� 2�߿� ���° ����ġ����")]
    [SerializeField] private int switchNum = 1;

    private bool isSwitchOn = false;

    public override void InteractionEvent()
    {
        if (isSwitchOn) return;

        isSwitchOn = true;
        SwitchGameManager.Inst.StartSwitchGame(switchNum);
    }
}
