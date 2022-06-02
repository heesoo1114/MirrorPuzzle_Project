using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCellar : InteractionObject
{
    public override void EnterInteraction()
    {
        GameManager.Inst.UI.ActiveTextPanal("지하실로 가는 길이다. \n 아직 들어갈 수 없는거 같다.");
    }

    public override void InteractionEvent()
    {
    }

}
