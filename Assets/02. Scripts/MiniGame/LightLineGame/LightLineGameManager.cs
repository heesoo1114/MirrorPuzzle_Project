using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightLineGameManager : MonoBehaviour
{
    public UnityEvent gameEndEvent;
    public UnityEvent gameResetEvent;

    private bool _isStart = false;

    public void Init()
    {
        if (_isStart == true) return;
        _isStart = true;
        gameObject.SetActive(true);
        transform.DOScale(Vector3.one, 0.8f).SetEase(Ease.InOutBounce);
    }

    public void ResetGame()
    {
        gameResetEvent?.Invoke();
    }

    public void GameEnd()
    {
        Sequence seq = DOTween.Sequence();
        GameManager.Inst.ChangeGameState(EGameState.UI);

        _isStart = false;
        seq.Append(transform.DOScale(Vector3.zero, 0.8f).SetEase(Ease.InOutBounce));
        seq.AppendCallback(() => gameEndEvent?.Invoke());
        seq.AppendCallback(() => gameObject.SetActive(false));
        
    }
}
