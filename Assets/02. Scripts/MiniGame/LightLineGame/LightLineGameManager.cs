using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightLineGameManager : SingleUI<LightLineGameManager>
{
    public UnityEvent gameEndEvent;
    public UnityEvent gameResetEvent;

    private bool _isStart = false;

    private bool _isClear = false;

    public bool IsClear => _isClear;

    public static void StartGame()
    {
        if (CheckInstance()) return;

        inst.StartLightGame();
    }

    public override bool Init()
    {
        if (base.Init())
        {
            return false;
        }

        _isStart = false;
        _isClear = false;
        transform.localScale = Vector3.zero;
        gameObject.SetActive(false);

        return true;
    }

    public void StartLightGame()
    {
        if (_isStart == true) return;
        if (_isClear) return;
        _isStart = true;
        gameObject.SetActive(true);
        transform.localScale = Vector3.one;
    }

    public void ResetGame()
    {
        gameResetEvent?.Invoke();
    }

    public void GameEnd()
    {
        GameManager.Inst.ChangeGameState(EGameState.Game);

        _isStart = false;
        _isClear = true;

        transform.localScale = Vector3.zero;
        gameEndEvent?.Invoke();
        InventorySystem.Inst.AddItem("LIBRARYKEY");
        gameObject.SetActive(false);

    }
}
