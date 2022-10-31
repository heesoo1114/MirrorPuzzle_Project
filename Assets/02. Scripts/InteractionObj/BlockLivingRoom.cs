using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockLivingRoom : InteractionObject
{
    public override void EnterInteraction()
    {
        TextSystem.Inst.ActiveTextPanal("2층에서 빨리 형을 찾아보자! \n 1층으로 내려갈 이유는 없는 거 같다.");
    }
}
