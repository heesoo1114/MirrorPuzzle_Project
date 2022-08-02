using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearSound : AudioPlayer
{
    [SerializeField] private AudioClip gameClearClip;

    public void GameClearrSound()
    {
        PlayClipWithRandnessPitch(gameClearClip);
    }
}
