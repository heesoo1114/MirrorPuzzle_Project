using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpZone : MonoBehaviour
{
    public Transform _warpPoint;
    public Vector2 _offset;

    public Vector2 WarpPoint
    {
        get => (Vector2)_warpPoint.position + _offset;
    }

}
