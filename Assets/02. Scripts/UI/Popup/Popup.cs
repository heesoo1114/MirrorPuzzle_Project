using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Popup : UIBase
{
    public enum EManageType
    {
        Default,

        /// <summary>
        /// Canvas 창에서 유지
        /// </summary>
        Maintain
    }

    [SerializeField]
    protected EManageType _manageType = EManageType.Default;

    public EManageType ManageType => _manageType;

    protected CanvasGroup _canvasGroup;
    protected bool _usedInterable;
    public override bool Init()
    {
        if(base.Init() == false)
        {
            return false;
        }

        _canvasGroup = GetComponent<CanvasGroup>();
        UIManager.Inst.SubstactPopup(this);
        _usedInterable = _canvasGroup.interactable;

        return true;
    }

    public virtual void OpenEvent()
    {
        _canvasGroup.alpha = 1f;

        if(_usedInterable)
        {
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
        }
    }

    public virtual void CloseEvent()
    {
        if(_manageType == EManageType.Default)
        {
            Destroy(gameObject);
            return;
        }

        _canvasGroup.alpha = 0f;
        if (_usedInterable)
        {
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }
    }

    public void ClosePopupUI()
    {
        UIManager.Inst.ClosePopupUI(this);
    }

}
