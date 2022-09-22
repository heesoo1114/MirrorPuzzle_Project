using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField]
    private PopupUISO _popupUIList;

    private Stack<Popup> _popupStack;

    public void ActivePopupUI(string keyID)
    {
        Popup popup = _popupUIList[keyID];
        ActivePopupUI(popup);
    }

    public void ActivePopupUI(Popup ui)
    {
        if (_popupStack.Peek() == ui || ui.gameObject.activeSelf)
            return;

        _popupStack.Push(ui);
        ui.gameObject.SetActive(true);
    }

    public void ClosePopupUI(Popup ui)
    {
        if (_popupStack.Count == 0)
            return;

        if (_popupStack.Peek() != ui)
        {
            Debug.Log("Close Failed");
            return;
        }

        ClosePopupUI();
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        Popup popup = _popupStack.Pop();
        
        if(popup.UsePooling)
        {
            // Ç®¸µ
        }

        else
        {
            Destroy(popup.gameObject);
        }
    }


}
