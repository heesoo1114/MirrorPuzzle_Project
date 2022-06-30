using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;


public class GameManager : MonoBehaviour
{
    enum GameState
    {
        Game,
        UI
    }


    public eColiderState coliderState;

    public static GameManager Inst;

    private UIManager uiManager;
    private CutSceneManager _cutSceneManager;

    private GameState _currentGameState;

    public UIManager UI { get { return uiManager; } }
    public bool IsUI => _currentGameState == GameState.UI;


    private WorldType worldType = WorldType.RealWorld;
    public WorldType WorldType { get { return worldType; } set { worldType = value; } }

    [SerializeField] private TextDatas _textDatas;

    public Light2D globalLight;
    public List<Room> rooms;
    public Transform map;

    public UnityEvent ChangeMirrorWorld;
    public UnityEvent ChangeRealWorld;

    private void Awake()
    {
        if(Inst != null)
        {
            Debug.LogError("게임 매니저 2개 이상임");
        }
        Inst = this;

        uiManager = GetComponent<UIManager>();
        _cutSceneManager = GetComponent<CutSceneManager>();

        _currentGameState = GameState.Game;
    }

    private void Start()
    {
        ChangeGlobalLight();

        for (int i = 0; i < map.childCount; i++)
        {
            // Room Type은 임시
            rooms.Add(new Room(map.GetChild(i).gameObject, RoomType.BigBrother));
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeWorld();
        }
    }

    private void ChangeWorld()
    {
        if (uiManager.isWorldBarMoving) return;

        if (worldType == WorldType.MirrorWorld)
        {
            worldType = WorldType.RealWorld;
            rooms.ForEach(x => x.roomObject.transform.localScale = Vector3.one);
            ChangeRealWorld?.Invoke();
        }
        else
        {
            worldType = WorldType.MirrorWorld;
            rooms.ForEach(x => x.roomObject.transform.localScale = new Vector3(-1f, 1f, 1f));
            ChangeMirrorWorld?.Invoke();
        }

        uiManager.ActiveWorldText(worldType);

        ChangeGlobalLight();
        Debug.Log(worldType.ToString());
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
        Debug.Log(id);
        return _textDatas.FindTextData(id);
    }

    public void PlayCutScene(string cutSceneID)
    {
        _cutSceneManager.PlayCutScene(cutSceneID);
    }

    public void SetGameState(bool onUI)
    {
        _currentGameState = onUI ? GameState.UI : GameState.Game;
    }
}