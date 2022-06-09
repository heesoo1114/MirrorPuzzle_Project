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

    private static Transform _playerTrs;

    public static Transform PlayerTransform
    {
        get
        {
            if (_playerTrs == null)
            {
                _playerTrs = GameObject.FindGameObjectWithTag("Player").transform;
            }

            return _playerTrs;
        }
    }

}
