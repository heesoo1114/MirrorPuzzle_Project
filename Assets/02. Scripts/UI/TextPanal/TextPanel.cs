using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextPanel : MonoBehaviour
{
    [SerializeField] private NameTextPanal _nameTextPanal;
    [SerializeField] private Text _currentText;
    [SerializeField] private float _textSpeed = 0.05f;
    private bool _isOutput;
    private string _currentStr;


    public void ShowTextPanal(string outputText, string name = "")
    {
        if (_isOutput) return;
        
        if(name != "")
        {
            _nameTextPanal.ChangeNameText(name);
            _nameTextPanal.gameObject.SetActive(true);
        }
        else
        {
            _nameTextPanal.gameObject.SetActive(false);
        }

        _isOutput = true;
        _currentStr = outputText;
        _currentText.text = "";
        transform.DOScaleX(0f, 0f);
        gameObject.SetActive(true);
        StartCoroutine(Co_ShowTextPanal());
    }

    public void UnShowTextPanal()
    {
        if (gameObject.activeSelf == false) return;

        if (_isOutput)
        {
            StopAllCoroutines();
            _currentText.DOKill();
            _isOutput = false;
        }

        StartCoroutine(Co_UnShowTextPanal());
    }

    private IEnumerator Co_ShowTextPanal()
    {
        transform.DOKill();
        transform.DOScaleX(1f, 0.5f);
        yield return new WaitForSeconds(0.5f);

        float time = _currentStr.Length * _textSpeed;

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
        _nameTextPanal.gameObject.SetActive(false);
        _currentText.text = "";

        GameManager.Inst.gameState = EGameState.Game;
    }
}
