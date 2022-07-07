using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpZone : MonoBehaviour
{
    public enum ERoomType
    {
        LivingRoom,
        Kitchen,
        Toilet,
        SecondFloorHallway,
        ElderBrotherRoom,
        YoungerBrotherRoom,
        Library,
        InnerRoom,
        Veranda,
        Celler
    }

    public Transform _warpPoint;
    public EFaceType spawnType;
    public ERoomType _targetRoom;
    [HideInInspector]
    public Vector2 _offset;

    public bool isLock;

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
            case ERoomType.LivingRoom:
                _roomName = "�Ž�";
                break;

            case ERoomType.Kitchen:
                _roomName = "�ξ�";
                break;

            case ERoomType.Toilet:
                _roomName = "ȭ���";
                break;

            case ERoomType.SecondFloorHallway:
                _roomName = "2�� ����";
                break;

            case ERoomType.ElderBrotherRoom:
                _roomName = "�� ��";
                break;

            case ERoomType.YoungerBrotherRoom:
                _roomName = "���� ��";
                break;

            case ERoomType.Library:
                _roomName = "����";
                break;

            case ERoomType.InnerRoom:
                _roomName = "�ȹ�";
                break;

            case ERoomType.Veranda:
                _roomName = "������";
                break;

            case ERoomType.Celler:
                _roomName = "���Ͻ�";
                break;
        }
    }

    public Vector2 WarpPoint
    {
        get => (Vector2)_warpPoint.position + _offset * 1.5f;
    }
}