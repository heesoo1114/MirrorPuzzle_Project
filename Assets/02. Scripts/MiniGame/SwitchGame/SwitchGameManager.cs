using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGameManager : MonoSingleton<SwitchGameManager>
{
    [SerializeField] private SwitchGame[] _switchGames;

    public void StartSwitchGame(int num)
    {
        _switchGames[num - 1].GameStart();
    }
}
