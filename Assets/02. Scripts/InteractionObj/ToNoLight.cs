using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNoLight : InteractionObject
{
    // 처음에 주방에서 불 꺼진곳으로 이동할 때 막기위해 쓰는 코드

    public override void EnterInteraction()
    {
        TextSystem.Inst.ActiveTextPanal("불이 꺼져 있다. \n 불을 켠 뒤 이동하자.");
    }
}
