using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameStarter : InteractionObject
{
    private bool _isClear =false;
    private bool _isPlaying = false;

    [SerializeField]
    private GameObject dishPuzzle;

    public override void InteractionEvent()
    {
        if (_isClear) return;
        if (_isPlaying) return;
        _isPlaying = true;

        dishPuzzle.SetActive(true);
    }

    private void GameClear()
    {
        _isClear = true;
    }

}
