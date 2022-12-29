using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIIManager : MonoBehaviour
{
    public FadeScreen fadeScreen;

    public GameObject _interactionImage;

    [SerializeField] private TextSystem _textPanal;


    private bool _showImage;

    public Image pwLetterImage;
    public Image letterImage;
    private Text letterText;
    public Image keypad;

    [SerializeField]
    private Text worldText;
    [SerializeField] private GameObject _toiletLetterUI;


    public bool isWorldBarMoving = false;

    //[SerializeField] private DishCreate _kitchenMinigameManager;
    [SerializeField] private SwitchGame _switchMiniGameManager1;
    [SerializeField] private SwitchGame _switchMiniGameManager2;
    [SerializeField] private LightLineGameManager _lightLineGameManager;

    private Coroutine _textCoroutine;

    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private CanvasGroup _canvasGroup;
    private bool _isSettingPanelOn;

    private void Update()
    {
        if (GameManager.Inst.GameState == EGameState.Timeline || isWorldBarMoving) return;

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SettingPanelOnOff();
        }
    }




    // 디폴트 파라메터, 기본 매개변수, 매개변수에 값이 들어온다면 그 값으로 초기화가 되고
    // 아무 값도 들어오지않는다면 선언되있는 값으로 초기화
    


  


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
        if (_lightLineGameManager.IsClear) return;

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
        //_kitchenMinigameManager.StartGame();
    }

    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
        print("the end");
    }

    public void ToTitleTest()
    {
        SceneManager.LoadScene("Title1");
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadGame()
    {

    }

    public void SettingPanelOnOff()
    {
        if (!_isSettingPanelOn && GameManager.Inst.GameState == EGameState.UI) return;

        if (_isSettingPanelOn == false) _settingPanel.SetActive(true);
        _canvasGroup.DOFade(_isSettingPanelOn ? 0f : 1f, 0.5f);
        _isSettingPanelOn = !_isSettingPanelOn;
        GameManager.Inst.ChangeGameState(_isSettingPanelOn ? EGameState.UI : EGameState.Game);
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
