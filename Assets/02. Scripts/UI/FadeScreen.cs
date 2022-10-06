using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : SingleUI<FadeScreen>
{
    public static Color fadeColor
    {
        set
        {
            if(inst == null)
            {
                Debug.Log("FadeScreen's inst doesn't exist");
                return;
            }

            Color color = value;
            color.a = 0f;
            inst._fadeImage.color = color; 
        }
    }

    private Image _fadeImage;
    private bool _isFade;

    public bool IsFade => _isFade;

    public override bool Init()
    {
        if (inst != null)
        {
            Debug.Log("FadeScreen's inst already exists");

            Destroy(gameObject);
            return false;
        }   
        
        if(base.Init() == false)
        {
            return false;
        }

        _isFade = false;
        inst = this;

        _fadeImage = GetComponent<Image>();
        _fadeImage.color = new Color(0,0,0,0);
        _fadeImage.raycastTarget = false;

        return true;
    }

    public static void StartFade(float duration = 1f)
    {
        if(CheckInstance())
        {
            return;
        }

        if(inst._isFade)
        {
            FadeIn(duration);
        }

        else
        {
            FadeOut(duration);
        }
    }

    public static void FadeIn(float duration = 1f)
    {
        if (!inst._isFade) return;
        inst._isFade = false;
        inst.FadeEffect(duration);
    }

    public static void FadeOut(float duration = 1f)
    {
        if (inst._isFade) return;
        inst._isFade = true;
        inst.FadeEffect(duration);
    }

    private void FadeEffect(float duration)
    {
        Color color = _fadeImage.color;
        color.a = _isFade ? 1f : 0f;

        _fadeImage.color = color;

        _fadeImage.DOFade(_isFade ? 0f : 1f, duration).SetEase(Ease.InCubic).OnComplete(() =>
        {
            Color color = Color.black;
            color.a = 0f;
            inst._fadeImage.color = color;
        });
    }

}
