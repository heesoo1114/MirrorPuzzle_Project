using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterUI : Popup
{
    private Text _letterText;

    private void Init()
    {
        _letterText = GetComponent<Text>();
    }

    public void OpenLetter(string text)
    {
        GameManager.Inst.ChangeGameState(EGameState.UI);
        _letterText.text = text;
        UIManager.Inst.ActivePopupUI(this);
    }

    public void CloseLetter()
    {
        GameManager.Inst.ChangeGameState(EGameState.Game);
        UIManager.Inst.ClosePopupUI(this);
    }


}
