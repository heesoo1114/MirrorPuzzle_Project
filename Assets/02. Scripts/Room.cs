using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Room
{
    public GameObject roomObject;
    public RoomType roomType;

    public Room(GameObject roomObj, RoomType type)
    {
        roomObject = roomObj;
        roomType = type;
    }
}
