using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPuzzleTrigger : InteractionObject
{
    [SerializeField] private GameObject sliderPuzzlePanel;
    [SerializeField] private GameObject ladder;
    public bool isClear = false;

    private void Start()
    {
        EventManager.StartListening("ClearPuzzle", PuzzleClear);
    }

    public override void InteractionEvent()
    {
        if (isClear) return;
        sliderPuzzlePanel.SetActive(true);
        GameManager.Inst.ChangeGameState(EGameState.UI);
    }

    void PuzzleClear()
    {
        sliderPuzzlePanel.SetActive(false);
        ladder.SetActive(true);
        GameManager.Inst.ChangeGameState(EGameState.Game);
    }
}
