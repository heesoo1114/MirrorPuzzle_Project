using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadPanel : MonoBehaviour
{
    private string number;

    private LockerKeypad locker;

    public void Init(LockerKeypad locker)
    {
        Text numberText = GetComponentInChildren<Text>();
        number = (transform.GetSiblingIndex() + 1).ToString();
        numberText.text = number;

        Button button = GetComponent<Button>();
        button.onClick.AddListener(InputButton);

    }

    private void InputButton()
    {
        if (locker.isInputKey == false)
        {
            return;
        }
        locker.InputPassword(number);
    }
}
