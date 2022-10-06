using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletDoorTrigger : InteractionObject
{
    [SerializeField] private bool isMirror;
    public override void InteractionEvent()
    {
        if(isMirror)
        {
            TextSystem.Inst.ActiveTextPanal("문이 무언가에 막힌듯 열리지 않는다. \n 다른 세계에서 한번 열어보자");
            return;
        }
        if (InventorySystem.Inst.equipItemDataID == "1114")
        {
            InventorySystem.Inst.UseEquipItem();
            TextSystem.Inst.ActiveTextPanal("문이 열렸다.");
            Invoke("CanOut", 1f);
        }
        else
        {
            Cantstop();
        }
    }

    public void CanOut()
    {
        EventManager.TriggerEvent("CLEAR_TOILET");
        gameObject.SetActive(false);
    }

    public void Cantstop()
    {
        TextSystem.Inst.ActiveTextPanal("문이 열리지 않는다. \n 오래된 문이라 자주 고장 나는 듯 하다.");
    }



}
