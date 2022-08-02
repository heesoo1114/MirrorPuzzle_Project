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
    public EGameState gameState;
    public eColiderState coliderState;


    private UIManager uiManager;

    public UIManager UI { get { return uiManager; } }


    private WorldType worldType = WorldType.RealWorld;
    public WorldType WorldType { get { return worldType; } set { worldType = value; } }

    [SerializeField] private TextDatas _textDatas;

    // ï¿½ï¿½ï¿½ï¿½ ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿?ï¿½ï¿½ï¿½ï¿½ ï¿½E ï¿½ï¿½ï¿½ï¿½
    [SerializeField] private List<CamState> _virtualCamList;


    public Light2D globalLight;
    public List<Room> rooms;
    public Transform map;

    public UnityEvent ChangeMirrorWorld;
    public UnityEvent ChangeRealWorld;

    public bool librayChestPuzzleClear = false;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();

        InitCameraManager();
    }

    private void InitCameraManager()
    {
        foreach(var camState in _virtualCamList) 
        {
            CameraManager.SubscribeCamera(camState.state, camState.cam);
        }

        CameraManager.SwitchCamera(ECameraState.TimelineCam);
    }

    private void Start() 
    {
        ChangeGlobalLight();

        rooms = map.GetComponentsInChildren<Room>().ToList();
    }

    private void Update()
    {
        if (gameState != EGameState.Game) return;
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
        return _textDatas.FindTextData(id);
    }
}