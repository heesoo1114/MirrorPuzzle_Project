using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoorTrigger : InteractionObject
{
    public override void InteractionEvent()
    {
        if (InventorySystem.Inst.equipItemDataID == "1114")
        {
            GameManager.Inst.UI.ActiveTextPanal("���� ���ȴ�.");
            Invoke("CanOut", 1.5f);
        }
    }

    public void CanOut()
    {
        gameObject.SetActive(false);
    }

    public void Cantstop()
    {
        GameManager.Inst.UI.ActiveTextPanal("���� ������ �ʴ´�. /n ������ ���̶� ���� ���� ���� �� �ϴ�.");
    }



}
