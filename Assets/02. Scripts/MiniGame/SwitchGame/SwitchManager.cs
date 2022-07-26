using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class SwitchManager : MonoBehaviour
{
    public Switch[] switches;
    public UnityEvent gameEndEvent;

    private bool _isStart = false;
    private int _isCheck = 0;
    private bool _isEnd = false;

    public void Init()
    {
        if (_isStart == true) return;
        _isStart = true;
        gameObject.SetActive(true);
        transform.DOScale(Vector3.one, 0.8f).SetEase(Ease.InOutBounce);
    }

    private void Update()
    {
        foreach (Switch swi in switches)
            if (swi.isOn == true) _isCheck++;

        if (_isCheck == 5 && _isEnd == false)
        {
            _isEnd = true;
            GameEnd();
        }
        else _isCheck = 0;
    }

    private void GameEnd()
    {
<<<<<<< HEAD
        GameManager.Inst.SetGameState(false);
=======
        GameManager.Inst.gameState = EGameState.Game;
>>>>>>> OIF
        _isStart = false;
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOScale(Vector3.zero, 0.8f).SetEase(Ease.InOutBounce));
        seq.AppendCallback(() => gameEndEvent?.Invoke());
        seq.AppendCallback(() => gameObject.SetActive(false));
    }
}
