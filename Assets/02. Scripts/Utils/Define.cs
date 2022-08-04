using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
    private static Camera _mainCam;

    public static Camera MainCam
    {
        get
        {
            if(_mainCam == null)
            {
                _mainCam = Camera.main;
            }

            return _mainCam;
        }
    }

    private static PlayerMove _playerRef;

    public static PlayerMove PlayerRef
    {
        get
        {
            if (_playerRef == null)
            {
                _playerRef = GameObject.FindObjectOfType<PlayerMove>();
            }

            return _playerRef;
        }
    }

}

