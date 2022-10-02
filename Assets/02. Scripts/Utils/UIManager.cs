using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    private Dictionary<string, Popup> _popupDict = new Dictionary<string, Popup>();
    private Stack<Popup> _popupStack;
    private Canvas _mainCanvas = null;

    private void Awake()
    {
        _mainCanvas = GameObject.Find("UI Canvas").GetComponent<Canvas>();
    }

    public void SubstactPopup(Popup popup)
    {
        if (!popup.gameObject.name.Contains(popup.GetType().ToString()))
        {
            popup.gameObject.name = popup.GetType().ToString();
        }

        if (!_popupDict.ContainsKey(name))
        {
            _popupDict.Add(popup.gameObject.name, popup);
        }
    }

    public T FindPopup<T>() where T : Popup
    {
        return _popupStack.Where(x => x.GetType() == typeof(T)).FirstOrDefault() as T;
    }

    public T PeekPopupUI<T>() where T : Popup
    {
        if (_popupStack.Count == 0)
            return null;

        return _popupStack.Peek() as T;
    }


    public void ActivePopupUI<T>() where T : Popup
    {
        string name = typeof(T).ToString();
        ActivePopupUI(name);
    }

    public void ActivePopupUI(string name)
    {
        Popup popup = null;

        if (_popupDict.TryGetValue(name, out popup))
        {
            if(popup.ManageType == Popup.EManageType.Default)
            {
                string popupName = popup.name;
                popup = Instantiate(popup, _mainCanvas.transform);
                popup.name = popupName;
            }

            ActivePopupUI(popup);
        }
    }

    public void ActivePopupUI(Popup ui)
    {
        if(!_popupDict.ContainsValue(ui))
        {
            SubstactPopup(ui);
        }

        if (_popupStack.Peek() == ui || ui.gameObject.activeSelf)
            return;

        _popupStack.Push(ui);
        ui.OpenEvent();
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
        popup.CloseEvent();
    }


}
