using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneDirector : MonoBehaviour
{
    public string cutSceneID;

    private PlayableDirector _playableDirector;
    [SerializeField] private CutSceneSO _currentCutScene;
    private bool _isPaused = false;
    public bool IsPuased => _isPaused;
    public CutSceneSO CurrentCutScene => _currentCutScene;

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
