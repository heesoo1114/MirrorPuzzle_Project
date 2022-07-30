using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneDirector : MonoBehaviour
{
    public string cutSceneID;

    private PlayableDirector _playableDirector;
    private bool _isPaused = false;
    public bool IsPuased => _isPaused;

    private void Awake()
    {
        _playableDirector = GetComponent<PlayableDirector>();
    }

    public void Play()
    {
        _playableDirector.Play(); 
        _isPaused = false;
    }

    public void Pause()
    {
        _playableDirector.Pause();
        _isPaused = true;
    }

}
