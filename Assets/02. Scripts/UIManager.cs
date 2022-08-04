using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public FadeScreen fadeScreen;

    public GameObject _interactionImage;
    public Vector3 _interactionOffset = new Vector2(0.2f, 0.2f);

    [SerializeField] private TextPanel _textPanal;


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
    [SerializeField] private GameObject _toiletLetterUI;


    public bool isWorldBarMoving = false;

    [SerializeField] private DishCreate _kitchenMinigameManager;
    [SerializeField] private SwitchManager _switchMiniGameManager1;
    [SerializeField] private SwitchManager _switchMiniGameManager2;
    [SerializeField] private LightLineGameManager _lightLineGameManager;

    private Coroutine _textCoroutine;

    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private CanvasGroup _canvasGroup;
    private bool _isSettingPanelOn;

    private void Update()
    {
        if (GameManager.Inst.GameState == EGameState.Timeline) return;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SettingPanelOnOff();
        }
    }

    public void ColorFade(Color color, bool isFade, float duration = 1f)
    {
        if (isFade)
        {
            fadeScreen.fadeColor = color;
            StartFadeOut(duration);
        }

        else
        {
            StartFadeIn(duration);
        }
    }

    public void StartFade(float duration = 1f)
    {
        fadeScreen.StartFade(duration);
    }

    public void StartFadeIn(float duration = 1f)
    {
        fadeScreen.FadeIn(duration);
    }

    public void StartFadeOut(float duration = 1f)
    {
        fadeScreen.FadeOut(duration);
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

        GameManager.Inst.ChangeGameState(EGameState.UI);

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
        if (currentPw.Contains(number))
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
        if (_textCoroutine != null)
        {
            StopCoroutine(_textCoroutine);
        }
        isWorldBarMoving = true;

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
        
        rectTransform.DOKill();
        rectTransform.DOAnchorPosX(0f, 0.3f).SetEase(Ease.OutQuad);
        yield return new WaitForSeconds(2f);
        rectTransform.DOAnchorPosX(-400f, 0.3f).SetEase(Ease.InQuad);
        isWorldBarMoving = false;
        rectTransform.gameObject.SetActive(false);
        _textCoroutine = null;
    }



    public void StartSwitchOnGame(int value)
    {
        GameManager.Inst.ChangeGameState(EGameState.UI);
        if (value == 1)
            _switchMiniGameManager1.Init();
        else if (value == 2)
            _switchMiniGameManager2.Init();
    }

    public void StartLightLineGame()
    {
        GameManager.Inst.ChangeGameState(EGameState.UI);
        _lightLineGameManager.Init();
    }

    public void ToiletLetterUI()
    {
        _toiletLetterUI.SetActive(true);
    }

    public void StartKitchenMingame()
    {
        GameManager.Inst.ChangeGameState(EGameState.UI);
        _kitchenMinigameManager.StartGame();
    }

    private bool isSettingPanelOn = false;

    public void NewGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadGame()
    {

    }

    public void SettingPanelOnOff()
    {
        if (isSettingPanelOn == false) _settingPanel.SetActive(true);
        _canvasGroup.DOFade(_isSettingPanelOn ? 0f : 1f, 0.5f);
        GameManager.Inst.ChangeGameState(_isSettingPanelOn ? EGameState.UI : EGameState.Game);
        _isSettingPanelOn = !_isSettingPanelOn;
        if (_isSettingPanelOn == false) _settingPanel.SetActive(false);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
    }
}
