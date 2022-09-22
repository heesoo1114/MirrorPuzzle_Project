using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField]
    private PopupUISO _popupUIList;

    private Stack<GameObject> _popupStack;

    public void ActivePopupUI(string keyID)
    {
        GameObject popup = _popupUIList[keyID];

        if (_popupStack.Peek() == popup || popup.activeSelf)
            return;

        _popupStack.Push(popup);
    }

}
