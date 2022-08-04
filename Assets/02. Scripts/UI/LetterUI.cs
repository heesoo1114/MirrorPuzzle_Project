using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterUI : MonoBehaviour
{
    public void CloseLetter()
    {
        GameManager.Inst.ChangeGameState(EGameState.Game);
        gameObject.SetActive(false);
    }
}
