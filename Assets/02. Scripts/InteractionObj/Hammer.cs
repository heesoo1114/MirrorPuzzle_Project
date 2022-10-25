using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : InteractionObject
{
    public GameObject letter;
    public override void InteractionEvent()
    {
        base.InteractionEvent();

        if (InventorySystem.Inst.equipItemDataID == "HAND_MIRROR")
        {
            if (!(GameManager.Inst.WorldType == WorldType.MirrorWorld)) return;
            Invoke("BrokeHandMirror", 1.8f);
            return;
        }

        TextSystem.Inst.ActiveTextPanal("���� �ִ� �ð踦 ��ġ�� ���� �ִ� ��ġ�̴�. \n �� ��ġ��� �ſ��� �� �� ���� �� ����.");
        letter.gameObject.SetActive(true);
    }

    public void BrokeHandMirror()
    {
        CutSceneManager.Inst.StartCutScene("END");
    }
}
