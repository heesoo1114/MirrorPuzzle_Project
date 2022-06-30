using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour // Ç®¸µ
{
    private CharacterData _currentData;
    private Animator _animator;

    public void Init(CharacterData data)
    {
        if(_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
        _currentData = data;
        _animator.runtimeAnimatorController = data.animatorCtrl;
    }

    public void Move(Vector2 reachPos, float duration, Ease ease)
    {
        transform.DOKill();

        transform.DOMove(reachPos, duration).SetEase(ease);
    }
}
