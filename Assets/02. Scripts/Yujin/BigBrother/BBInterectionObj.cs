using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBInterectionObj : InteractionObject
{
    public enum EObjectName
    {
        None,
        SmallPlant,
        PocketClock,
        Table,
        Bears
    }

    public EObjectName eObject;

    public override void InteractionEvent()
    {
        if (eObject == EObjectName.SmallPlant)
        {
            
            Debug.Log("����ȭ��");
        }
        else if (eObject == EObjectName.PocketClock)
        {
            Debug.Log("ȸ�߽ð�");
        }
        else if (eObject == EObjectName.Table)
        {
            Debug.Log("���̺�");
        }
        else if (eObject == EObjectName.Bears)
        {
            Debug.Log("����");
            // ���̶� �Ѿ� �� ������ �����۵���
            //if()
        }

    }

}
