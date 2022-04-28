using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public Image _fadeImage;

    public GameObject _interactionImage;

    [SerializeField] private TextPanal _textPanal;

    public bool OnUI;

    private bool _showImage;

    public void FadeScreen(bool isFade)
    {
        _fadeImage.DOFade(isFade ? 1f : 0f, 0.5f);
    }

    // 디폴트 파라메터, 기본 매개변수, 매개변수에 값이 들어온다면 그 값으로 초기화가 되고
    // 아무 값도 들어오지않는다면 선언되있는 값으로 초기화
    public void ActiveTextPanal(string value = "")
    {
        if(value == "")
        {
            Debug.Log("d");
            _textPanal.UnShowTextPanal(); 
        }

        else
        {
            _textPanal.ShowTextPanal(value);
        }
    }

    public bool IsActiveTextPanal()
    {
        return _textPanal.gameObject.activeSelf;
    }


    public void ShowInteractionUI(Vector3 targetPos)
    {
        if (_showImage) return;

        if(!_interactionImage.activeSelf)
        {
            _interactionImage.transform.localScale = Vector3.zero;
            _interactionImage.transform.DOKill();
            _interactionImage.SetActive(true);
            _interactionImage.transform.position = targetPos;
            _interactionImage.transform.DOScale(Vector3.one, 0.3f);
            _interactionImage.transform.DOMove(targetPos + new Vector3(0.7f, 0.7f), 0.5f).OnComplete(()=>
             _showImage = false);
            _showImage = true;
        }

        else
        {
            _interactionImage.transform.position= targetPos + new Vector3(0.7f, 0.7f);
        }
    }

    public void UnShowInteractionUI()
    {
        // 람다식 방식 코루틴으로 변경
        _interactionImage.transform.DOKill();
        _showImage = false;
        _interactionImage.SetActive(false);
    }
}
