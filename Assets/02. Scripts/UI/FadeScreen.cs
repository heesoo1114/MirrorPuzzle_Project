using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    public Color fadeColor = Color.black;
    private Image _fadeImage;

    private bool _isFade;

    public bool IsFade => _isFade;

    private void Awake()
    {
        _fadeImage = GetComponent<Image>();
    }



    public void StartFade(float duration = 1f)
    {
        if(_isFade)
        {
            FadeIn(duration);
        }

        else
        {
            FadeOut(duration);
        }
    }

    public void FadeIn(float duration = 1f)
    {
        if (!_isFade) return;
        _isFade = false;
        FadeEffect(duration);
    }

    public void FadeOut(float duration = 1f)
    {
        if (_isFade) return;
        _isFade = true;
        FadeEffect(duration);
    }

    private void FadeEffect(float duration)
    {
        Debug.Log("dd");
        Color color = fadeColor;
        color.a = _isFade ? 1f : 0f;

        _fadeImage.color = color;

        _fadeImage.DOFade(_isFade ? 0f : 1f, duration).SetEase(Ease.InCubic).OnComplete(() => fadeColor =Color.black);
    }

}
