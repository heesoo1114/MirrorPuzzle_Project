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

    private UIManager uiManager;

    public UIManager UI { get { return uiManager; } }


    private WorldType worldType = WorldType.RealWorld;
    public WorldType WorldType { get { return worldType; } set { worldType = value; } }

    [SerializeField] private TextDatas _textDatas;

    public Light2D globalLight;
    public List<Room> rooms;
    public Transform map;

    public UnityEvent ChangeMirrorWorld;
    public UnityEvent ChangeRealWorld;

    public bool librayChestPuzzleClear = false;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();

    }

    private IEnumerator Start() 
    {
        ChangeGlobalLight();

        rooms = map.GetComponentsInChildren<Room>().ToList();

        yield return new WaitForEndOfFrame();

        CutSceneManager.Inst.StartCutScene("CELLER");
    }

    public void ChangeWorld()
    {
        if (uiManager.isWorldBarMoving) return;

        StartCoroutine(ChangeWorldCoroutine());
    }

    private IEnumerator ChangeWorldCoroutine()
    {
        uiManager.ColorFade(Color.white, false, 0.5f);
        yield return new WaitForSeconds(0.5f);
        uiManager.ColorFade(Color.white, true, 0.5f);

        if (worldType == WorldType.MirrorWorld)
        {
            worldType = WorldType.RealWorld;
            rooms.ForEach(x => x.transform.localScale = Vector3.one);
            ChangeRealWorld?.Invoke();
        }
        else
        {
            worldType = WorldType.MirrorWorld;
            rooms.ForEach(x => x.transform.localScale = new Vector3(-1f, 1f, 1f));
            ChangeMirrorWorld?.Invoke();
        }

        uiManager.ActiveWorldText(worldType);

        ChangeGlobalLight();
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
    }

    public void SetBackGameState()
    {
        _gameState = _beforeGameState;
    }
}