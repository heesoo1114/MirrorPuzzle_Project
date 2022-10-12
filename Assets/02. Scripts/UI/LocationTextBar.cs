using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationTextBar : SingleUI<LocationTextBar>
{
    private Text _locationText;
    RectTransform _rectTransform;
    Coroutine _textCoroutine = null;

    public override bool Init()
    {
        if (base.Init() == false)
        {
            return false;
        }

        Bind(out _locationText, "LocationText");
        _rectTransform = GetComponent<RectTransform>();

        return true;
    }

    public static void ActiveWorldText(WorldType worldType)
    {
        inst.ShowWorldText(worldType == WorldType.MirrorWorld ? "거울세계" : "현실세계");
    }

   
    public static void ActiveRoomText(string roomName)
    {
        inst.ShowWorldText(roomName);
    }

    private void ShowWorldText(string text)
    {
        _locationText.text = text;

        if (_textCoroutine != null)
        {
            StopCoroutine(_textCoroutine);
        }

        _textCoroutine = StartCoroutine(MoveUIBar());
    }


    private IEnumerator MoveUIBar()
    {
        _rectTransform.DOKill();
        _rectTransform.DOAnchorPosX(0f, 0.3f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(2f);
        _rectTransform.DOAnchorPosX(-400f, 0.3f).SetEase(Ease.InQuad);
        _textCoroutine = null;
    }

}
