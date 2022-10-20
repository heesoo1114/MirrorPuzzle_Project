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

    private IEnumerator Start() 
    {
        ChangeGlobalLight();
        Cursor.lockState = CursorLockMode.Locked;

        rooms = map.GetComponentsInChildren<Room>().ToList();

        yield return new WaitForEndOfFrame();

        SoundManager.Inst.BgmStart(Util.Bgm.Main);
        
        CutSceneManager.Inst.StartCutScene("LIBRARY");
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

            foreach(var room in rooms)
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