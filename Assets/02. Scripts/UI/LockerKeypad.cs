using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockerKeypad : Popup
{
    private const string PASSWORD = "85672";
    private string currentPw = "";

    private Text pwText;
    private Transform _keypadTrm;

    [HideInInspector]
    public bool isInputKey = true;

    public override bool Init()
    {
        if(base.Init() == false)
        {
            return false;
        }

        _manageType = EManageType.Default;
        isInputKey = true;
        Bind(out pwText, "Password/PasswordText");
        _keypadTrm = transform.GetChild(0);
        GameManager.Inst.ChangeGameState(EGameState.UI);

        KeypadPanel[] keypadPanels = transform.Find("Keypad").GetComponentsInChildren<KeypadPanel>();

        foreach(KeypadPanel keypad in keypadPanels)
        {
            keypad.Init(this);
        }

        return true;
    }

    private void CheckPassword()
    {
        if (PASSWORD == currentPw)
        {
            EventManager.TriggerEvent("ClearLockerKeypad");
            GameManager.Inst.ChangeGameState(EGameState.Game);
            ClosePopupUI();
        }
        else
        {
            _keypadTrm.DOShakePosition(0.5f, 20);
        }
    }

    public void InputPassword(string number)
    {
        if (currentPw.Contains(number))
        {
            _keypadTrm.DOShakePosition(0.5f, 20);
            return;
        }

        currentPw += number;
        pwText.text = currentPw;
        if (currentPw.Length == PASSWORD.Length)
        {
            CheckPassword();
            currentPw = "";
            StartCoroutine(ResetPw());
        }
    }
    IEnumerator ResetPw()
    {
        isInputKey = false;
        yield return new WaitForSeconds(1f);
        pwText.text = currentPw;
        isInputKey = true;
    }
}
