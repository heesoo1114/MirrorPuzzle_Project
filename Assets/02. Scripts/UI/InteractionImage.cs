using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionImage : SingleUI<InteractionImage>
{
    private Image _currentImage;
    private bool _showImage = false;
    private Vector3 _interactionOffset = new Vector2(0.2f, 0.2f);


    public override bool Init()
    {
        if (base.Init() == false)
        {
        return false;
        }

        _currentImage = GetComponent<Image>();
        return true;
    }

    public static void Show(Vector3 targetPos)
    {
        if (CheckInstance()) return;

        inst.ShowInteractionUI(targetPos);
    }
    public static void UnShow()
    {
        if (CheckInstance()) return;

        inst.UnShowInteractionUI();
    }

    private void ShowInteractionUI(Vector3 targetPos)
    {
        if (_showImage) return;

        if (!gameObject.activeSelf)
        {
            _currentImage.transform.localScale = Vector3.zero;
            _currentImage.transform.DOKill();
            _currentImage.gameObject.SetActive(true);
            _currentImage.transform.position = targetPos;
            _currentImage.transform.DOScale(Vector3.one, 0.3f);
            _currentImage.transform.DOMove(targetPos + _interactionOffset, 0.5f).
                OnComplete(() => _showImage = false);

            _showImage = true;
        }

        else
        {
            _currentImage.transform.position = targetPos + _interactionOffset;
        }
    }

    private void UnShowInteractionUI()
    {
        // 람다식 방식 코루틴으로 변경
        _currentImage.transform.DOKill();
        _showImage = false;
        _currentImage.gameObject.SetActive(false);
    }
}
