using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionToLivingRoomTrigger : InteractionObject
{
    public void OpenLivingRoom()
    {
        TextSystem.Inst.ActiveTextPanal("이제 가보자.");
        StartCoroutine(ImmediatelyStop());   
    }

    IEnumerator ImmediatelyStop()
    {
        yield return new WaitForSeconds(1.5f);
        this.gameObject.SetActive(false);
    }

    public override void EnterInteraction()
    {
        TextSystem.Inst.ActiveTextPanal("빛나고있는 쪽지를 얻고 가자.");
    }
}
