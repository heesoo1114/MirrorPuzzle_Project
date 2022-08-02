using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoorTrigger : InteractionObject
{
    public override void InteractionEvent()
    {
        if (InventorySystem.Inst.equipItemDataID == "1114")
        {
            GameManager.Inst.UI.ActiveTextPanal("문이 열렸다.");
            Invoke("CanOut", 1.5f);
        }
    }

    public void CanOut()
    {
        gameObject.SetActive(false);
    }

    public void Cantstop()
    {
        GameManager.Inst.UI.ActiveTextPanal("문이 열리지 않는다. /n 오래된 문이라 자주 고장 나는 듯 하다.");
    }



}
