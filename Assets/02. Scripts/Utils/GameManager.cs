using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
<<<<<<< HEAD
        if (uiManager.isWorldBarMoving) return;

        if (worldType == WorldType.RealWorld)
=======
        if (worldType == WorldType.MirrorWorld)
>>>>>>> HaYeon
        {
            worldType = WorldType.RealWorld;
            rooms.ForEach(x => x.roomObject.transform.localScale = Vector3.one);
        }
        else
        {
            worldType = WorldType.MirrorWorld;
            rooms.ForEach(x => x.roomObject.transform.localScale = new Vector3(-1f, 1f, 1f));
        }

        uiManager.ActiveWorldText(worldType);

        ChangeGlobalLight();
        Debug.Log(worldType.ToString());
    }

    private void ChangeGlobalLight()
    {
        if (worldType == WorldType.RealWorld)
        {
<<<<<<< HEAD
            globalLight.intensity = 1f;
=======
            globalLight.intensity = 0.8f;
>>>>>>> HaYeon
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
}