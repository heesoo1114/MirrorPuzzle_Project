using System;
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
    private string _textMessage;

    public bool IsOutput => _isOutput;

    public Action OnKeyDownSpace;

    private EGameState _beforeGameState;


    public void Update()
    {
        if (gameObject.activeSelf == false) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (OnKeyDownSpace != null)
            {
                OnKeyDownSpace?.Invoke();
            }

            else
            {
                if (_isOutput)
                {
                    ImmediatelyEndOutput();
                }

                else
                {
                    UnShowTextPanal();
                }
            }
        }
    }

    public void ShowTextPanal(string outputText, string name = "")
    {
        if (_isOutput) return;
        if (name != "")
        {
            _nameTextPanal.ChangeNameText(name);
            _nameTextPanal.gameObject.SetActive(true);
        }
        else
        {
            _nameTextPanal.gameObject.SetActive(false);
        }
        if (GameManager.Inst.GameState != EGameState.Timeline)
        {
            GameManager.Inst.ChangeGameState(EGameState.UI);
        }

        _isOutput = true;
        _textMessage = outputText;
        _currentText.text = "";
        transform.DOScaleX(0f, 0f);
        gameObject.SetActive(true);
        StartCoroutine(Co_ShowTextPanal());
    }

    public void ImmediatelyEndOutput()
    {
        if (_isOutput == false) return;

        _currentText.DOKill();
        _currentText.text = _textMessage;
        _isOutput = false;
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

        float time = _textMessage.Length * _textSpeed;

        _currentText.DOKill();
        _currentText.text = "";
        _currentText.DOText(_textMessage, time);

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

        if(GameManager.Inst.GameState == EGameState.UI)
            GameManager.Inst.ChangeGameState(_beforeGameState);

    }
}
