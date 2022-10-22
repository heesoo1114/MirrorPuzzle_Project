using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Rendering;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class UIManager : MonoSingleton<UIManager>
{
    private Dictionary<string, Popup> _popupDict = new Dictionary<string, Popup>();
    private Stack<Popup> _popupStack = new Stack<Popup>();
    private Canvas _mainCanvas = null;

    [SerializeField]
    private PopupListSO _popupListData = null;

    private void Awake()
    {
        _mainCanvas = GameObject.Find("UI Canvas").GetComponent<Canvas>();
        _popupStack = new Stack<Popup>();
        SubstactPopupPref();
    }

    private void SubstactPopupPref()
    {
        if (_popupListData == null)
        {
            Addressables.LoadAssetAsync<PopupListSO>("PopupListSO").Completed += (handle) =>
            {
                if (handle.Status == AsyncOperationStatus.Succeeded)
                {
                    _popupListData = handle.Result;
                }
            };
        }

        _popupListData.popupList.ForEach(x => SubstactPopup(x));
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
            if (popup.ManageType == Popup.EManageType.Default)
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
        if (!_popupDict.ContainsValue(ui))
        {
            SubstactPopup(ui);
        }

        if (_popupStack.Count != 0)
        {
            if (_popupStack?.Peek() == ui || ui.gameObject.activeSelf)
                return;
        }

        _popupStack.Push(ui);
        ui.OpenEvent();
        ui.gameObject.SetActive(true);
    }

    public void ClosePopupUI(Popup ui)
    {
        if (_popupStack.Count == 0)
            return;

        while (_popupStack.Peek() != ui)
        {
            if (_popupStack.Count == 0)
            {
                Debug.LogError("Popup Error");
                return;
            }
            ClosePopupUI();
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
