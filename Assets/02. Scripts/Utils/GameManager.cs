using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;

    public UIManager UIManger { get { return uiManager; } }

    private WorldType worldType = WorldType.RealWorld;
    public WorldType WorldType { get { return worldType; } set { worldType = value; } }

    public RoomType currentRoom;

    public Light2D globalLight;
    public GameObject tileMapGrid;

    public List<Room> rooms;

    public bool isChangingRoom;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();

    }

    private void Start()
    {
        ChangeGlobalLight();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeWorld();
        }
    }

    private void ChangeWorld()
    {
        if (worldType == WorldType.RealWorld)
        {
            worldType = WorldType.MirrorWorld;
        }
        else
        {
            worldType = WorldType.RealWorld;
        }

        if (tileMapGrid.transform.localScale.x > 0f)
        {
            tileMapGrid.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            tileMapGrid.transform.localScale = Vector3.one;
        }
        ChangeGlobalLight();
        Debug.Log(worldType.ToString());
    }

    private void ChangeGlobalLight()
    {
        if (worldType == WorldType.RealWorld)
        {
            globalLight.intensity = 0.1f;
        }
        else
        {
            globalLight.intensity = 1f;
        }
    }

    public void ChangeRoom(RoomType room)
    {
        if (isChangingRoom) return;
        isChangingRoom = true;
        currentRoom = room;
        UIManger.ChangeRoom(LoadRoom);
    }

    private void LoadRoom()
    {
        rooms.ForEach(x => x.roomObject.gameObject.SetActive(false));
        Room room = rooms.Find(x => x.roomType == currentRoom);
        room.roomObject.gameObject.SetActive(true);
        isChangingRoom = false;
    }
}