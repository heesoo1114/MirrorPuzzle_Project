using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBroherObjInterction : InteractionObject
{
    


    public override void InteractionEvent()
    {
        if (GameObject.Find("PocketWatch"))
        {
            Debug.Log("ȸ�߽ð�");
            // �κ��丮�� �Ķ� �Ѿ� 3��
        }
        else if (GameObject.Find("SmallPlant"))
        {
            Debug.Log("���� ȭ��");
            // �κ��丮�� �Ķ� �Ѿ� 3��
        }
        else if (GameObject.Find("Table"))
        {
            Debug.Log("å��");
            // �κ��丮�� ���� �Ѿ� 3��
        }
        else
        {
            Debug.Log("����� �� ���� ������");
        }
    }
}
