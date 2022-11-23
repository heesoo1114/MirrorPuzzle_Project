using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchObject : InteractionObject
{
    // 현재는 1 또는 2만 있음
    [Header("1또는 2중에 몇번째 스위치인지")]
    [SerializeField] private int switchNum = 1;

    private bool isSwitchOn = false;

    public override void InteractionEvent()
    {
        if (isSwitchOn) return;

        isSwitchOn = true;
        SwitchGameManager.Inst.StartSwitchGame(switchNum);
    }
}
