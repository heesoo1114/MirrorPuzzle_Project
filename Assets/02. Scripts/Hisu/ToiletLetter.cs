using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletLetter : MonoBehaviour
{

    public void EndLetter()
    {
        GameManager.Inst.ChangeGameState(EGameState.Game);
    }
}
