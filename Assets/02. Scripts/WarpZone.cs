using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpZone : MonoBehaviour
{
    public Transform warpPoint;
    public EFaceType spawnType;

    public RoomType currentRoom;
    public RoomType targetRoom;
    
    [HideInInspector]
    public Vector2 offset;
    [HideInInspector]
    public bool isLock;
    [HideInInspector]
    public string lockMessage;

    private string _roomName = "";
    public string RoomName
    {
        get => _roomName;
    }

    private void Start()
    {
        switch (spawnType)
        {
            case EFaceType.Right:
                offset = Vector2.right;
                break;
            case EFaceType.Left:
                offset = Vector2.left;
                break;
            case EFaceType.Up:
                offset = Vector2.up;
                break;
            case EFaceType.Down:
                offset = Vector2.down;
                break;
        }

        switch (targetRoom)
        {
            case RoomType.LivingRoom:
                _roomName = "�Ž�";
                break;

            case RoomType.Kitchen:
                _roomName = "�ξ�";
                break;

            case RoomType.Toilet:
                _roomName = "ȭ���";
                break;

            case RoomType.HallWay:
                _roomName = "2�� ����";
                break;

            case RoomType.BigBrother:
                _roomName = "�� ��";
                break;

            case RoomType.SmallBrother:
                _roomName = "���� ��";
                break;

            case RoomType.Library:
                _roomName = "����";
                break;

            case RoomType.BedRoom:
                _roomName = "�ȹ�";
                break;

            case RoomType.Veranda:
                _roomName = "������";
                break;

            case RoomType.Celler:
                _roomName = "���Ͻ�";
                break;
        }
    }

    public Vector2 WarpPoint
    {
        get => (Vector2)warpPoint.position + offset * 1.5f;
    }
}