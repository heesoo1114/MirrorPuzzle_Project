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

    // ����Ʈ �Ķ����, �⺻ �Ű�����, �Ű������� ���� ���´ٸ� �� ������ �ʱ�ȭ�� �ǰ�
    // �ƹ� ���� �������ʴ´ٸ� ������ִ� ������ �ʱ�ȭ
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
        // ���ٽ� ��� �ڷ�ƾ���� ����
        _interactionImage.transform.DOKill();
        _showImage = false;
        _interactionImage.SetActive(false);
    }
}
