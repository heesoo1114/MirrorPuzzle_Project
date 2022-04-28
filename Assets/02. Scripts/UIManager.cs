using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public GameObject _textPanal;
    public Text _textPanalText;
    public Image _fadeImage;

    public GameObject _interactionImage;

    private Coroutine _showTextCoroutine;
    private Coroutine _unShowTextCoroutine;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowTextPanal("안은 생각보다 깨끗한걸?");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UnShowTextPanal();
        }


    }
    public void FadeScreen(bool isFade)
    {
        _fadeImage.DOFade(isFade ? 1f : 0f, 0.5f);
    }

    public void ShowTextPanal(string outputText)
    {
        if (_showTextCoroutine != null) return;

        if (_unShowTextCoroutine != null)
        {
            StopCoroutine(_unShowTextCoroutine);
            _unShowTextCoroutine = null;
        }

        _textPanalText.text = "";
        _textPanal.transform.DOScaleX(0f, 0f);
        _textPanal.SetActive(true);
        _showTextCoroutine = StartCoroutine(Co_ShowTextPanal(outputText));
    }

    public void UnShowTextPanal()
    {
        if (_unShowTextCoroutine != null) return;

        if (_showTextCoroutine != null)
        {
            StopCoroutine(_showTextCoroutine);
            _showTextCoroutine = null;
        }

        _unShowTextCoroutine = StartCoroutine(Co_UnShowTextPanal());
    }

    private IEnumerator Co_ShowTextPanal(string outputText)
    {
        _textPanal.transform.DOKill();
        _textPanal.transform.DOScaleX(1f, 0.5f);
        yield return new WaitForSeconds(0.5f);

        _textPanalText.DOKill();
        _textPanalText.DOText(outputText, outputText.Length * 0.03f);

        yield return new WaitForSeconds(outputText.Length * 0.03f);

        _showTextCoroutine = null;
    }

    private IEnumerator Co_UnShowTextPanal()
    {
        _textPanal.transform.DOKill();
        _textPanal.transform.DOScaleX(0f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        _textPanal.SetActive(false);
        _textPanalText.text = "";
        _unShowTextCoroutine = null;

    }

    public void ShowInteractionUI(Vector3 targetPos)
    {
        
        if(!_interactionImage.activeSelf)
        {
            _interactionImage.transform.localScale = Vector3.zero;
            _interactionImage.transform.DOKill();
            _interactionImage.SetActive(true);
            _interactionImage.transform.position = targetPos;
            _interactionImage.transform.DOScale(Vector3.one, 0.3f);
            _interactionImage.transform.DOMove(targetPos + new Vector3(0.7f, 0.7f), 0.5f);
        }

        else
        {
            //_interactionImage.transform.position= targetPos + new Vector3(0.7f, 0.7f);
        }
    }

    public void UnShowInteractionUI()
    {
        // 람다식 방식 코루틴으로 변경
        _interactionImage.transform.DOKill();
        _interactionImage.SetActive(false);
    }
}
