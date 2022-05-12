using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpZone : MonoBehaviour
{
    public Transform _warpPoint;
    public SpawnType spawnType;
    [HideInInspector]
    public Vector2 _offset;

    private void Start()
    {
        switch(spawnType)
        {
            case SpawnType.Right:
                _offset = Vector2.right;
                break;
            case SpawnType.Left:
                _offset = Vector2.left;
                break;
            case SpawnType.Up:
                _offset = Vector2.up;
                break;
            case SpawnType.Down:
                _offset = Vector2.down;
                break;
        }
    }

    public Vector2 WarpPoint
    {
        get => (Vector2)_warpPoint.position + _offset * 1.5f;
    }
}