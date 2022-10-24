using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionToLivingRoomTrigger : InteractionObject
{
    [SerializeField] private GameObject _brotherNote;
    public void OpenLivingRoom()
    {
        TextSystem.Inst.ActiveTextPanal("���� ������.");
        StartCoroutine(ImmediatelyStop());   
    }

    IEnumerator ImmediatelyStop()
    {
        yield return new WaitForSeconds(1.5f);
        _brotherNote.SetActive(false);
        this.gameObject.SetActive(false);
    }

    public override void EnterInteraction()
    {
        TextSystem.Inst.ActiveTextPanal("�������ִ� ������ ��� ����.");
    }
}
