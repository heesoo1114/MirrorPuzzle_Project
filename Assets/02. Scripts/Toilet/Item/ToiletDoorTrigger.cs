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
            TextSystem.Inst.ActiveTextPanal("���� ���𰡿� ������ ������ �ʴ´�. \n �ٸ� ���迡�� �ѹ� �����");
            return;
        }
        if (InventorySystem.Inst.equipItemDataID == "1114")
        {
            InventorySystem.Inst.UseEquipItem();
            TextSystem.Inst.ActiveTextPanal("���� ���ȴ�.");
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
        TextSystem.Inst.ActiveTextPanal("���� ������ �ʴ´�. \n ������ ���̶� ���� ���� ���� �� �ϴ�.");
    }



}
