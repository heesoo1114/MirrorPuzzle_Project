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
        if(InventorySystem.Inst.EqualsItem("BB_BlueBullet") &&
           InventorySystem.Inst.EqualsItem("BB_RedBullet") &&
           InventorySystem.Inst.EqualsItem("BB_NotRealGun"))
        {
            // √—¿Ã∂˚ √—æÀ¿Ã ¥Ÿ ¿÷¥Ÿ∏È if
            reloadPanel.gameObject.SetActive(true);
        }
        else
        {
            base.InteractionEvent();
        }
    }
}
