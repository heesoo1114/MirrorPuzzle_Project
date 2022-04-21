using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public Image _fadeImage;


    public void FadeScreen(bool isFade)
    {
        _fadeImage.DOFade(isFade ? 1f : 0f, 0.5f);
    }
}
