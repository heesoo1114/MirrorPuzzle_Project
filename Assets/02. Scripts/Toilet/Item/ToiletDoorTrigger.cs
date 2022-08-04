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
            GameManager.Inst.UI.ActiveTextPanal("���� ���𰡿� ������ ������ �ʴ´�. \n �ٸ� ���迡�� �ѹ� �����");
            return;
        }
        if (InventorySystem.Inst.equipItemDataID == "1114")
        {
            InventorySystem.Inst.UseEquipItem();
            GameManager.Inst.UI.ActiveTextPanal("���� ���ȴ�.");
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
        GameManager.Inst.UI.ActiveTextPanal("���� ������ �ʴ´�. \n ������ ���̶� ���� ���� ���� �� �ϴ�.");
    }



}
