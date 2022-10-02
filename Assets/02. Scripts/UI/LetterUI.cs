using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterUI : Popup
{
    private Text _letterText;
    private static LetterUI _inst = null;

    public override bool Init()
    {
        if(_init)
        {
            Destroy(gameObject);
            return false;
        }

        if (base.Init() == false)
        {
            return false;
        }

        _manageType = EManageType.Maintain; 
        Bind<Text>(out _letterText, "LetterText");
        _inst = this;
        return true;
    }

    public static void OpenLetter(string text)
    {
        if (_inst == null)
        {
            Debug.LogError("LetterUI's inst doesn't exist");
            return;
        }

        GameManager.Inst.ChangeGameState(EGameState.UI);
        _inst._letterText.text = text;
        UIManager.Inst.ActivePopupUI(_inst);
    }

    public override void CloseEvent()
    {
        base.CloseEvent();
        GameManager.Inst.ChangeGameState(EGameState.Game);
    }

}
