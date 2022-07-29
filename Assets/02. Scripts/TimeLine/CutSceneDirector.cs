using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneDirector : MonoBehaviour
{
    public string cutSceneID;

    private PlayableDirector _playableDirector;

    private void Awake()
    {
        _playableDirector = GetComponent<PlayableDirector>();
    }

    public void Play()
    {
        _playableDirector.Play();
    }

}
