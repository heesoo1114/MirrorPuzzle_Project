using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ButtonEffect : MonoBehaviour
{
    private bool isUsing = false;
    private bool isEnd = false;

    public void ScaleToBig()
    {
        if (isUsing == true) return;
        isEnd = false;
        isUsing = true;
        transform.DOScale(1.5f, 0.5f);
    }

    public void ScaleToSmall()
    {
        if (isEnd == true) return;
        isUsing = false;
        isEnd = true;
        transform.DOScale(1f, 0.5f);
    }
}

