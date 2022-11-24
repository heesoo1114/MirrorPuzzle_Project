using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MissionCheck : InteractionObject
{
    [SerializeField] 
    private GameObject blockPuzzle;
    [SerializeField]
    private GameObject exitButton;

    private bool _play;

    private Board board;

    private void Start()
    {
        _play = false;
        board = GetComponent<Board>();
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && _play)
        {
            GameManager.Inst.ChangeGameState(EGameState.Game);
        }
    }
    public override void InteractionEvent()
    {
        if (!_play)
        {
            GameManager.Inst.ChangeGameState(EGameState.UI);
            blockPuzzle.gameObject.SetActive(true);
            exitButton.gameObject.SetActive(true);
        }
    }

    public override void ExitInteraction()
    {
        GameManager.Inst.ChangeGameState(EGameState.Game);
        blockPuzzle.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }
}
