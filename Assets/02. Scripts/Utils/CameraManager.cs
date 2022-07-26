using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public static class CameraManager
{
    private static Dictionary<ECameraState, CinemachineVirtualCameraBase> _cameraDict = new Dictionary<ECameraState, CinemachineVirtualCameraBase>();
    private static ECameraState _currentCameraState;

    public static ECameraState CurrentCamState => _currentCameraState;

    public static void SubscribeCamera(ECameraState state, CinemachineVirtualCameraBase cam)
    { 
        if(_cameraDict == null)
        {
            _cameraDict = new Dictionary<ECameraState, CinemachineVirtualCameraBase>();
            _currentCameraState = state;
        }

        if(_cameraDict.ContainsKey(state))
        {
            _cameraDict[state] = cam;
        }

        else
        {
            _cameraDict.Add(state, cam);
        }
    }

    public static void SwitchCamera(ECameraState state)
    {
        if (_currentCameraState == state) return;
        if (!_cameraDict.ContainsKey(state)) return;

        _currentCameraState = state;
        var currentCam = _cameraDict[_currentCameraState];

        foreach(var cam in _cameraDict)
        {
            cam.Value.Priority = 0;
        }

        currentCam.Priority = 10;
    }

}
