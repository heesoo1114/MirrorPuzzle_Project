using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionToLivingRoomTrigger : InteractionObject
{
    public void OpenLivingRoom()
    {
        TextSystem.Inst.ActiveTextPanal("���� ������.");
        StartCoroutine(ImmediatelyStop());   
    }

    IEnumerator ImmediatelyStop()
    {
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }

    public override void EnterInteraction()
    {
        TextSystem.Inst.ActiveTextPanal("�������ִ� ������ ��� ����.");
    }
}
