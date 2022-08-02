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
        // √—¿Ã∂˚ √—æÀ¿Ã ¥Ÿ ¿÷¥Ÿ∏È if
        reloadPanel.gameObject.SetActive(true);

        //else 
        base.InteractionEvent();

    }
}
