using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BB_BearsPuzzle : InteractionObject
{
    [SerializeField]
    private Image reloadPanel;

    public override void InteractionEvent()
    {
        // ���̶� �Ѿ��� �� �ִٸ� if
        reloadPanel.gameObject.SetActive(true);

        //else 
        base.InteractionEvent();

    }
}
