using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
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
}
