using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : InteractionObject
{
    public override void InteractionEvent()
    {
        base.InteractionEvent();

        if (InventorySystem.Inst.equipItemDataID == "HAND_MIRROR")
        {
            if (!(GameManager.Inst.WorldType == WorldType.MirrorWorld)) return;
            Invoke("BrokeHandMirror", 1.8f);
            return;
        }

        TextSystem.Inst.ActiveTextPanal("옆에 있는 시계를 고치기 위해 있던 망치이다. \n 이 망치라면 거울을 깰 수 있을 것 같다.");
    }

    public void BrokeHandMirror()
    {
        CutSceneManager.Inst.StartCutScene("END");
    }
}
