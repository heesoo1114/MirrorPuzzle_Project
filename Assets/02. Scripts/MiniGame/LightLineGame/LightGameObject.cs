using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGameObject : InteractionObject
{
    public bool isClear = false;
    public LightLineGameManager _firstGame;

    public override void InteractionEvent()
    {
        if (isClear) return;

        _firstGame.StartLightGame();
    }

    public void GameClear()
    {
        isClear = true;
    }
}
