using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionToLivingRoomTrigger : InteractionObject
{
    public void OpenLivingRoom()
    {
        GameManager.Inst.UI.ActiveTextPanal("이제 가보자.");
        StartCoroutine(ImmediatelyStop());   
    }

    IEnumerator ImmediatelyStop()
    {
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }

    public override void EnterInteraction()
    {
        GameManager.Inst.UI.ActiveTextPanal("왼쪽 위에 있는 쪽지를 얻고 가자.");
    }
}
