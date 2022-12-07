using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwitchCloser : MonoBehaviour
{
    [SerializeField] private UnityEvent _closeEvent;

    public void SwitchClose()
    {
        gameObject.SetActive(false);
        _closeEvent?.Invoke();
        GameManager.Inst.ChangeGameState(EGameState.Game);
    }
}
