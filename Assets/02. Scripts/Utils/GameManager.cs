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

    public Light2D globalLight;
    public List<Room> rooms;
    public Transform map;

    public UnityEvent ChangeMirrorWorld;
    public UnityEvent ChangeRealWorld;

    private bool _isChangingWorld = false;
    public bool librayChestPuzzleClear = false;

    [SerializeField] GameObject player;
    private InteractionKey interactionKey;
    private InteractionBrotherNote interactionBrotherNote;
    private ToiletLetterInteraction toiletLetterInteraction;
    private ToiletKeyInteraction toiletKeyInteraction;
    private InteractionHandMirror interactionHandMirror;
    private LightLineGameManager lightLineGameManager;
    private LibraryCloset libraryCloset;
    private ChestScripts chestScripts;
    private LibraryBoxPuzzle libraryBoxPuzzle;
    private BigBrotherRoomKey bigBrotherRoomKey;
    private FilmPuzzle filmPuzzle;
    private PasswardScript passwardScript;

    private IEnumerator Start()
    {
        ChangeGlobalLight();
        Cursor.lockState = CursorLockMode.Locked;

        rooms = map.GetComponentsInChildren<Room>().ToList();

        yield return new WaitForEndOfFrame();

        SoundManager.Inst.BgmStart(Util.Bgm.Main);


        // CutSceneManager.Inst.StartCutScene("START");
    }

    public void ChangeWorld()
    {
        if (_isChangingWorld) return;

        _isChangingWorld = true;
        StartCoroutine(ChangeWorldCoroutine());
    }

    private IEnumerator ChangeWorldCoroutine()
    {
        PlayerMove player = Define.PlayerRef;

        FadeScreen.fadeColor = Color.white;
        FadeScreen.FadeOut(0.5f);
        yield return new WaitForSeconds(0.5f);
        FadeScreen.FadeIn(0.5f);

        if (worldType == WorldType.MirrorWorld)
        {
            worldType = WorldType.RealWorld;

            foreach (var room in rooms)
            {
                if (room.roomType == player.CurrentRoom)
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
            foreach (var room in rooms)
            {
                if (room.roomType == player.CurrentRoom)
                {
                    player.transform.SetParent(room.transform);
                }

                room.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            player.transform.SetParent(null);
            player.transform.localScale = Vector3.one;
            ChangeMirrorWorld?.Invoke();
        }

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

        if (_gameState != EGameState.Game)
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

    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.Save();
    }

    public void GameLoad()
    {
        if (!PlayerPrefs.HasKey("PlayerX"))
        {
            return;
        }
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        player.transform.position = new Vector3(x, y, 0f);
    }
}