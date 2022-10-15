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
           // GameManager.Inst.UI.StartFadeIn(2f);
            Invoke("BrokeHandMirror", 1.8f);
            return;
        }

        //GameManager.Inst.UI.ActiveTextPanal("���� �ִ� �ð踦 ��ġ�� ���� �ִ� ��ġ�̴�. \n �� ��ġ��� �ſ��� �� �� ���� �� ����.");
    }

    public void BrokeHandMirror()
    {
        CutSceneManager.Inst.StartCutScene("END");
    }
}
