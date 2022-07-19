using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpZone : MonoBehaviour
{
    public Transform _warpPoint;
    public EFaceType spawnType;
    public RoomType _targetRoom;
    [HideInInspector]
    public Vector2 _offset;

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
                _offset = Vector2.right;
                break;
            case EFaceType.Left:
                _offset = Vector2.left;
                break;
            case EFaceType.Up:
                _offset = Vector2.up;
                break;
            case EFaceType.Down:
                _offset = Vector2.down;
                break;
        }

        switch (_targetRoom)
        {
            case RoomType.LivingRoom:
                _roomName = "거실";
                break;

            case RoomType.Kitchen:
                _roomName = "부엌";
                break;

            case RoomType.Toilet:
                _roomName = "화장실";
                break;

            case RoomType.HallWay:
                _roomName = "2층 복도";
                break;

            case RoomType.BigBrother:
                _roomName = "형 방";
                break;

            case RoomType.SmallBrother:
                _roomName = "동생 방";
                break;

            case RoomType.Library:
                _roomName = "서재";
                break;

            case RoomType.BedRoom:
                _roomName = "안방";
                break;

            case RoomType.Veranda:
                _roomName = "베란다";
                break;

            case RoomType.Celler:
                _roomName = "지하실";
                break;
        }
    }

    public Vector2 WarpPoint
    {
        get => (Vector2)_warpPoint.position + _offset * 1.5f;
    }
}