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

    public Light2D globalLight;
    public List<Room> rooms;
    public Transform map;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
    }

    private void Start()
    {
        ChangeGlobalLight();

        for (int i = 0; i < map.childCount; i++)
        {
            // Room TypeÀº ÀÓ½Ã
            rooms.Add(new Room(map.GetChild(i).gameObject, RoomType.BigBrother));
        }
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
        if (uiManager.isWorldBarMoving) return;

        if (worldType == WorldType.RealWorld)
        {
            worldType = WorldType.MirrorWorld;
            rooms.ForEach(x => x.roomObject.transform.localScale = new Vector3(-1f, 1f, 1f));
        }
        else
        {
            worldType = WorldType.RealWorld;
            rooms.ForEach(x => x.roomObject.transform.localScale = Vector3.one);
        }

        uiManager.ActiveWorldText(worldType);

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
}