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
        GameManager.Inst.gameState = EGameState.UI;

        _isStart = false;
        transform.DOScale(Vector3.zero, 0.8f).SetEase(Ease.InOutBounce)
            .OnComplete(() => gameEndEvent?.Invoke()).OnComplete(() => gameObject.SetActive(false));
    }
}
