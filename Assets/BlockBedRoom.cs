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
            TextSystem.Inst.ActiveTextPanal("������ �ȹ濡 �� ������ ���� �� ����.");
        }
    }

    private void BlockRemove()
    {
        gameObject.SetActive(false);
    }
}
