using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextPanal : MonoBehaviour
{
    private UIManager _uiManager;
    private Text _currentText;
    private bool _isOutput;
    private string _currentStr;

    void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
        _currentText = GetComponentInChildren<Text>();
        gameObject.SetActive(false);    
    }
    public void ShowTextPanal(string outputText)
    {
        if (_isOutput) return;

        _isOutput = true;
        _currentStr = outputText;
        _currentText.text = "";
        transform.DOScaleX(0f, 0f);
        gameObject.SetActive(true);
        StartCoroutine(Co_ShowTextPanal());
    }

    public void UnShowTextPanal()
    {
        if (_isOutput)
        {
            _isOutput = false;
            _currentText.text = _currentStr;
            _currentText.DOKill();
            StopAllCoroutines();
            return;
        }

        StartCoroutine(Co_UnShowTextPanal());
    }

    private IEnumerator Co_ShowTextPanal()
    {
        transform.DOKill();
        transform.DOScaleX(1f, 0.5f);
        yield return new WaitForSeconds(0.5f);

        float time = _currentStr.Length * 0.03f;

        _currentText.DOKill();
        _currentText.DOText(_currentStr, time);

        yield return new WaitForSeconds(time);

        _isOutput = false;
    }

    private IEnumerator Co_UnShowTextPanal()
    {
        transform.DOKill();
        transform.DOScaleX(0f, 0.5f);
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        _currentText.text = "";

        _uiManager.OnUI = false;
    }
}
