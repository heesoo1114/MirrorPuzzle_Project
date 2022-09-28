using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : UIBase
{
    public enum EManageState
    {
        Default,
        Pooling,
        Maintain
    }

    [SerializeField]
    protected EManageState _manageState;

    public EManageState ManageState => _manageState;

    public override bool Init()
    {
        if(base.Init() == false)
        {
            return false;
        }

        return true;
    }

    public virtual void ClosePopupUI()
    {
        UIManager.Inst.ClosePopupUI(this);
    }
}
