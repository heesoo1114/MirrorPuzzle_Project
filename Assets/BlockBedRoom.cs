using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBedRoom : InteractionKey
{
    private void Start()
    {
        EventManager.StartListening("CLEAR_0TOILET", BlockRemove);
    }

    public override void InteractionEvent()
    {
        if (gameObject.activeSelf)
        {
            TextSystem.Inst.ActiveTextPanal("아직은 안방에 갈 이유가 없는 것 같다.");
        }
    }

    private void BlockRemove()
    {
        gameObject.SetActive(false);
    }
}
