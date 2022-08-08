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

    private bool _isClear = false;

    public bool IsClear => _isClear;
    public void Init()
    {
        if (_isStart == true) return;
        if (_isClear) return;
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
        GameManager.Inst.ChangeGameState(EGameState.Game);

        _isStart = false;
        seq.Append(transform.DOScale(Vector3.zero, 0.8f).SetEase(Ease.InOutBounce));
        seq.AppendCallback(() => {
            _isClear = true;
            gameEndEvent?.Invoke();
            InventorySystem.Inst.AddItem("LIBRARYKEY");
            gameObject.SetActive(false);
            });
        
    }
}
