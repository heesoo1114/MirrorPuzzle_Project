using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChangeWorld : MonoBehaviour
{
    public GameObject now;
    public GameObject mirror;
    public Image blackImage;

    private bool isNow = true;
    private bool isPlaying = false;

    private void Update()
    {
        // 거울 앞에서 상호작용
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Change();
        }
    }

    private void Change()
    {
        if (isPlaying == true) return;
        if (isNow == true)
        {
            StartCoroutine(DoblackScaleMove());
            Invoke("isNowOn", 0.5f);
        }
        else if (isNow == false)
        {
            StartCoroutine(DoblackScaleMove());
            Invoke("isMirrorOn", 0.5f);
        }
    }

    IEnumerator DoblackScaleMove()
    {
        isPlaying = true;
        blackImage.rectTransform.DOScale(1f, 0.25f);
        yield return new WaitForSeconds(0.5f);
        blackImage.rectTransform.DOScale(0f, 0.25f);
        isPlaying = false;
    }

    private void isNowOn()
    {
        now.SetActive(false);
        mirror.SetActive(true);
        isNow = false;
    }

    private void isMirrorOn()
    {
        now.SetActive(true);
        mirror.SetActive(false);
        isNow = true;
    }
}
