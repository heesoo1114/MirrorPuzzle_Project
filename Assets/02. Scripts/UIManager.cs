using System;
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

    public Image pwLetterImage;
    public Image letterImage;
    private Text letterText;
    public Image keypad;
    private const string PASSWORD = "85672";
    private string currentPw = "";

    [SerializeField]
    private GameObject key;
    [SerializeField] private Text pwText;
    [HideInInspector]
    public bool isInputKey = true;

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


    private void Start()
    {
        letterText = letterImage.transform.GetChild(0).GetComponent<Text>();
    }

    public void SetActivePwLetter(bool isActive)
    {
        pwLetterImage.gameObject.SetActive(isActive);
        pwLetterImage.transform.localScale = Vector3.zero;
        pwLetterImage.transform.DOScale(1f, 0.3f);
    }

    public void SetActiveLetter(string letter = "")
    {
        bool isActive;

        if (letter.Length > 0)
            isActive = true;
        else
            isActive = false;

        letterImage.gameObject.SetActive(isActive);
        letterImage.transform.localScale = Vector3.zero;
        letterImage.transform.DOScale(1f, 0.3f);

        letterText.text = letter;
    }


    public void SetActiveLocker(bool isActive)
    {
        keypad.gameObject.SetActive(isActive);
    }

    private void CheckPassword()
    {
        if (PASSWORD == currentPw)
        {
            keypad.gameObject.SetActive(false);
            key.gameObject.SetActive(true);
        }
        else
        {
            keypad.transform.GetChild(0).DOShakePosition(0.5f, 20);
        }
    }

    public void InputPassword(string number)
    {
        currentPw += number;
        pwText.text = currentPw;
        if (currentPw.Length == PASSWORD.Length)
        {
            CheckPassword();
            currentPw = "";
            StartCoroutine(ResetPw());
        }
    }
    IEnumerator ResetPw()
    {
        isInputKey = false;
        yield return new WaitForSeconds(1f);
        pwText.text = currentPw;
        isInputKey = true;
    }

    public void ChangeRoom(Action loadRoom)
    {
        // TODO: �� �ٲٴ� �ִϸ��̼�
        loadRoom.Invoke();
    }
}
