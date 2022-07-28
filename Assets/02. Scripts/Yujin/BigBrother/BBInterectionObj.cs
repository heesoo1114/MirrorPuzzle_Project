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
            
            Debug.Log("작은화분");
        }
        else if (eObject == EObjectName.PocketClock)
        {
            Debug.Log("회중시계");
        }
        else if (eObject == EObjectName.Table)
        {
            Debug.Log("테이블");
        }
        else if (eObject == EObjectName.Bears)
        {
            Debug.Log("베어");
            // 총이랑 총알 다 있으면 퍼즐작동함
            //if()
        }

    }

}
