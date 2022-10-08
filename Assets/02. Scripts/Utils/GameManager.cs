using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;

    private UIManager uiManager;

    public UIManager UI { get { return uiManager; } }

    private WorldType worldType = WorldType.RealWorld;
    public WorldType WorldType { get { return worldType; } set { worldType = value; } }

    [SerializeField] private TextDatas _textDatas;
    public bool OnUI;


    public Light2D globalLight;
    public List<Room> rooms;
    public Transform map;

    public UnityEvent ChangeMirrorWorld;
    public UnityEvent ChangeRealWorld;

    public GameObject player;

    private void Awake()
    {
        if(Inst != null)
        {
            Debug.LogError("게임 매니저 2개 이상임");
        }
        Inst = this;

        uiManager = GetComponent<UIManager>();
    }

    private void Start()
    {
        GameLoad();
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

    public void GameSave()
    {
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.Save();
    }

    public void GameLoad()
    {
        if(!PlayerPrefs.HasKey("PlayerX"))
        {
            return;
        }
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        player.transform.position = new Vector3(x, y, 0f);
    }
}