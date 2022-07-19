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
        get => (Vector2)_warpPoint.position + _offset * 1.5f;
    }
}