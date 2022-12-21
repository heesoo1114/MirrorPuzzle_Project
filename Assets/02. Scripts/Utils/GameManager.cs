using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public enum EGameState
{
    Game,
    UI,
    Timeline
}


public class GameManager : MonoSingleton<GameManager>
{
    private EGameState _beforeGameState;
    private EGameState _gameState;
    public EGameState GameState => _gameState;

    private WorldType worldType = WorldType.RealWorld;
    public WorldType WorldType { get { return worldType; } set { worldType = value; } }

    [SerializeField] private TextDatas _textDatas;

    [SerializeField] private Texture2D _cursorIcon;

    public Light2D globalLight;
    public List<Room> rooms;    
    public Transform map;

    public UnityEvent ChangeMirrorWorld;
    public UnityEvent ChangeRealWorld;

    private bool _isChangingWorld = false;
    private bool _isGameStart = false;
    public bool librayChestPuzzleClear = false;
    public bool isCanUseHandMirror = true;

    private void Awake()
    {
        Cursor.SetCursor(_cursorIcon, new Vector2(_cursorIcon.width, _cursorIcon.height), CursorMode.Auto);
    }

    private IEnumerator Start() 
    {
        ChangeGlobalLight();

        rooms = map.GetComponentsInChildren<Room>().ToList();

        yield return new WaitForEndOfFrame();

        SoundManager.Inst.BgmStart(Util.Bgm.Main);

        // 컷신 테스트
        // CutSceneManager.Inst.StartCutScene("TOILET");

        // Start 컷신 재생
        if (PlayerPrefs.GetInt("StartCutScene") == 0)
             _isGameStart = (PlayerPrefs.GetInt("StartCutScene") == 1);

        if (!_isGameStart)
        {
            // CutSceneManager.Inst.StartCutScene("START");
            _isGameStart = true;
            if (_isGameStart)
                PlayerPrefs.SetInt("StartCutScene", 1);
        }
    }

    [ContextMenu("ChangeWorld")]
    public void ChangeWorld()
    {
        _isChangingWorld = true;
        StartCoroutine(ChangeWorldCoroutine());
    }

    private IEnumerator ChangeWorldCoroutine()
    {
        PlayerMove player = Define.PlayerRef;

        FadeScreen.fadeColor = Color.white;
        FadeScreen.FadeIn(1.5f);
        

        if (worldType == WorldType.MirrorWorld)
        {
            worldType = WorldType.RealWorld;

            SoundManager.Inst.BgmStop(Util.Bgm.MirrorWorld);
            SoundManager.Inst.BgmStart(Util.Bgm.Main);
            
            foreach (var room in rooms)
            {
                if(room.roomType == player.CurrentRoom)
                {
                    player.transform.SetParent(room.transform);
                }

                room.transform.localScale = Vector3.one;
            }

            player.transform.SetParent(null);
            player.transform.localScale = Vector3.one;
            ChangeRealWorld?.Invoke();
        }
        else
        {
            worldType = WorldType.MirrorWorld;

            SoundManager.Inst.BgmStop(Util.Bgm.Main);
            SoundManager.Inst.BgmStart(Util.Bgm.MirrorWorld);

            foreach (var room in rooms)
            {
                if (room.roomType == player.CurrentRoom)
                {
                    player.transform.SetParent(room.transform);
                }

                room.transform.localScale = new Vector3(-1f, 1f, 1f);
            }

            yield return new WaitForSeconds(0.1f);

            player.transform.SetParent(null);
            player.transform.localScale = Vector3.one; // 여기는 바꾸면 안 될텐데
            ChangeMirrorWorld?.Invoke();
        }

        FadeScreen.FadeOut(1.4f);
        LocationTextBar.ActiveWorldText(worldType);

        ChangeGlobalLight();

        _isChangingWorld = false;
    }

    private void ChangeGlobalLight()
    {
        if (worldType == WorldType.RealWorld)
        {
            globalLight.intensity = 0.8f;
        }
        else
        {
            globalLight.intensity = 0.1f;
        }
    }

    public string FindTextData(string id)
    {
        return _textDatas.FindTextData(id);
    }

    public void ChangeGameState(EGameState state)
    {
        _beforeGameState = _gameState;
        _gameState = state;

        if(_gameState != EGameState.Game)
        {
            Cursor.lockState = CursorLockMode.None;
        }

        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }


    public void SetBackGameState()
    {
        _gameState = _beforeGameState;
    }

    public void SetGameStateToUI()
    {
        ChangeGameState(EGameState.Game);
    }
}