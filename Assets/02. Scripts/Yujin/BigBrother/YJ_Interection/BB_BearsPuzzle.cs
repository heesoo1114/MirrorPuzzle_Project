using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BB_BearsPuzzle : InteractionObject
{
    [SerializeField]
    private Image reloadPanel;

    private bool _isTuto;
    public override void InteractionEvent()
    {
        if (InventorySystem.Inst.EqualsItem("BB_BlueBullet") &&
           InventorySystem.Inst.EqualsItem("BB_RedBullet") &&
           InventorySystem.Inst.EqualsItem("BB_NotRealGun"))
        {
            // √—¿Ã∂˚ √—æÀ¿Ã ¥Ÿ ¿÷¥Ÿ∏È if
            GameManager.Inst.ChangeGameState(EGameState.UI);
            reloadPanel.gameObject.SetActive(true);
            if (_isTuto == false)
            {
                _isTuto = true;
                CutSceneManager.Inst.StartCutScene("BEAR");
            }
        }
        else
        {
            base.InteractionEvent();
        }
    }
}
