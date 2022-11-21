using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextSystem : MonoSingleton<TextSystem>
{
    [SerializeField] private NameTextPanal _nameTextPanal;
    [SerializeField] private Text _currentText;
    [SerializeField] private float _textSpeed = 0.05f;
    private bool _isOutput;
    private string _textMessage;

    public bool IsOutput => _isOutput;

    public Action OnKeyDownSpace;

    private EGameState _beforeGameState;

    private void Awake()
    {
        if (inst != null)
        {
            Destroy(gameObject);
            return;
        }

        inst = this;
    }

    public void ActiveTextPanal(string value = "")
    {
        if (value == "")
        {
            if (gameObject.activeSelf)
            {
                UnShowTextPanal();
            }

            else
            {
                return;
            }
        }

        else
        {
            ShowTextPanal(value);
        }
    }


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
                    UnShowTextPanal();
                }

                else
                {
                    UnShowTextPanal();
                }
            }
        }
    }

    public bool ShowTextPanal(string outputText, string name = "")
    {
        if (_isOutput) return false;
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

        if (!gameObject.activeSelf)
        {
            transform.DOScaleX(0f, 0f);
            gameObject.SetActive(true);
        }

        StopAllCoroutines();
        StartCoroutine(Co_ShowTextPanal());
        return true;
    }

    public void ImmediatelyEndOutput()
    {
        if (_isOutput == true) return;

        _isOutput = false;
        _currentText.DOKill(true);
        _currentText.text = _textMessage;
    }

    public void UnShowTextPanal()
    {
        if (gameObject.activeSelf == false) return;

        if (_isOutput)
        {
            StopAllCoroutines();
            _currentText.DOKill(true);
            _isOutput = false;
        }

        StartCoroutine(Co_UnShowTextPanal());
    }

    private IEnumerator Co_ShowTextPanal()
    {
        if (transform.localScale.x != 1f)
        {
            transform.DOScaleX(1f, 0.2f);
            yield return new WaitForSeconds(0.2f);
        }

        float time = _textMessage.Length * _textSpeed;

        _currentText.DOKill();
        _currentText.text = "";
        _currentText.DOText(_textMessage, time);

        yield return new WaitForSeconds(time);

        _isOutput = false;
    }

    private IEnumerator Co_UnShowTextPanal()
    {
        transform.DOScaleX(0f, 0.2f);
        yield return new WaitForSeconds(0.2f);
        gameObject.SetActive(false);
        _nameTextPanal.gameObject.SetActive(false);
        _currentText.text = "";

        if (GameManager.Inst.GameState == EGameState.UI)
            GameManager.Inst.ChangeGameState(_beforeGameState);
    }
}
