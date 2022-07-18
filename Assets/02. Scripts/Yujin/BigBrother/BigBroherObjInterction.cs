using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBroherObjInterction : InteractionObject
{
    


    public override void InteractionEvent()
    {
        if (GameObject.Find("PocketWatch"))
        {
            Debug.Log("회중시계");
            // 인벤토리에 파랑 총알 3개
        }
        else if (GameObject.Find("SmallPlant"))
        {
            Debug.Log("작은 화분");
            // 인벤토리에 파랑 총알 3개
        }
        else if (GameObject.Find("Table"))
        {
            Debug.Log("책상");
            // 인벤토리에 빨강 총알 3개
        }
        else
        {
            Debug.Log("평범한 형 방의 물건임");
        }
    }
}
