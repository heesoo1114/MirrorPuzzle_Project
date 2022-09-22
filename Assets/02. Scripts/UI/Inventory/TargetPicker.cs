using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetPicker : MonoBehaviour
{
    private bool _isMove;

    public bool IsMove => _isMove;

    private void OnDisable()
    {
        transform.DOKill(true);
    }
    public void SetPos(Vector2 pos, float duration = 0.25f)
    {
        _isMove = true;
        transform.DOMove(pos, duration).OnComplete(() => _isMove = false);
    }
}
