using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class SwitchGame : UIBase
{
    public Switch[] switches;
    public UnityEvent gameEndEvent;

    private bool _isStart = false;
    private int _isCheck = 0;
    private bool _isEnd = false;

    public override bool Init()
    {
        if (base.Init() == false)
        {
            return false;
        }

        _isStart = false;
        _isCheck = 0;
        _isEnd = false;

        transform.localScale = Vector3.zero;

        return true;
    }
    public void GameStart()
    {
        if (_isStart) return;
        _isStart = true;
        gameObject.SetActive(true);
        transform.DOScale(Vector3.one, 0.8f).SetEase(Ease.InOutBounce);
        GameManager.Inst.ChangeGameState(EGameState.UI);
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
        GameManager.Inst.ChangeGameState(EGameState.Game);
        _isStart = false;
        Sequence seq = DOTween.Sequence();
        seq.Append(transform.DOScale(Vector3.zero, 0.8f).SetEase(Ease.InOutBounce));
        seq.AppendCallback(() => gameEndEvent?.Invoke());
        seq.AppendCallback(() => gameObject.SetActive(false));
    }
}
