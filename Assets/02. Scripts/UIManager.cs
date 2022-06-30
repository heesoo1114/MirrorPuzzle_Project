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
    public Vector3 _interactionOffset = new Vector2(0.2f, 0.2f);

    [SerializeField] private TextPanal _textPanal;


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

    [SerializeField]
    private Text worldText;

    public bool isWorldBarMoving = false;

    [SerializeField] private BugManager _minigameManager;
    [SerializeField] private SwitchManager _switchMiniGameManager1;
    [SerializeField] private SwitchManager _switchMiniGameManager2;

    private Coroutine _textCoroutine;

    public void FadeScreen(bool isFade)
    {
        _fadeImage.DOFade(isFade ? 1f : 0f, 0.5f);
    }

    // 디폴트 파라메터, 기본 매개변수, 매개변수에 값이 들어온다면 그 값으로 초기화가 되고
    // 아무 값도 들어오지않는다면 선언되있는 값으로 초기화
    public void ActiveTextPanal(string value = "")
    {
        if (value == "")
        {
            if (IsActiveTextPanal())
            {
                _textPanal.UnShowTextPanal();
            }

            else
            {
                return;
            }
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

        if (!_interactionImage.activeSelf)
        {
            _interactionImage.transform.localScale = Vector3.zero;
            _interactionImage.transform.DOKill();
            _interactionImage.SetActive(true);
            _interactionImage.transform.position = targetPos;
            _interactionImage.transform.DOScale(Vector3.one, 0.3f);
            _interactionImage.transform.DOMove(targetPos + _interactionOffset, 0.5f).OnComplete(() =>
             _showImage = false);
            _showImage = true;
        }

        else
        {
            _interactionImage.transform.position = targetPos + _interactionOffset;
        }
    }

    public void UnShowInteractionUI()
    {
        // 람다식 방식 코루틴으로 변경
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
        if(currentPw.Contains(number))
        {
            keypad.transform.GetChild(0).DOShakePosition(0.5f, 20);
            return;
        }

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

    public void ActiveWorldText(WorldType worldType)
    {
        RectTransform rectTransform = worldText.transform.parent.GetComponent<RectTransform>();

        if (worldType == WorldType.MirrorWorld)
        {
            worldText.text = "거울세계";
        }
        else
        {
            worldText.text = "현실세계";
        }
        if(_textCoroutine != null)
        {
            StopCoroutine(_textCoroutine);
        }

        _textCoroutine = StartCoroutine(MoveUIBar(rectTransform));
    }

    public void ActiveRoomText(string roomName)
    {
        RectTransform rectTransform = worldText.transform.parent.GetComponent<RectTransform>();
        worldText.text = roomName;
        StartCoroutine(MoveUIBar(rectTransform));
    }

    private IEnumerator MoveUIBar(RectTransform rectTransform)
    {
        rectTransform.gameObject.SetActive(true);
        isWorldBarMoving = true;
        rectTransform.DOKill();
        rectTransform.DOAnchorPosX(0f, 0.3f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(2f);
        rectTransform.DOAnchorPosX(-400f, 0.3f).SetEase(Ease.InQuad);
        isWorldBarMoving = false;
        rectTransform.gameObject.SetActive(false);
        _textCoroutine = null;
    }

    public void StartMiniGame()
    {
        GameManager.Inst.SetGameState(true);
        _minigameManager.Init();
    }

    public void StartSwitchOnGame(int value)
    {
        GameManager.Inst.SetGameState(true);
        if (value == 1)
            _switchMiniGameManager1.Init();
        else if (value == 2)
            _switchMiniGameManager2.Init();
    }
}
