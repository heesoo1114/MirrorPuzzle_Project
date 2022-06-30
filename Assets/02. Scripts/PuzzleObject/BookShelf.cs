using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System;

public class BookShelf : MonoBehaviour
{
    [Header("상호작용 거리")]
    [SerializeField]
    private float distance = 3f;

    private int curShakeCount = 0;
    private const int SHAKE_COUNT = 5;

    private Transform playerTransform;
    private Vector2 firstPosition;

    public UnityEvent onCompleteShake;

    private void Start()
    {
        playerTransform = Define.PlayerTransform;
        firstPosition = transform.position;
    }
    private void OnMouseDown()
    {
        if (curShakeCount >= SHAKE_COUNT) return;
        if (Vector2.Distance(playerTransform.position, transform.position) < distance)
        {
            transform.DOShakePosition(0.4f, 0.25f).OnComplete(ResetPosition);
            curShakeCount++;

            if (curShakeCount >= SHAKE_COUNT)
            {
                onCompleteShake.Invoke();
            }
        }
    }

    private void ResetPosition()
    {
        transform.position = firstPosition;
    }

}
