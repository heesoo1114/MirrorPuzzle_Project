using UnityEngine;
using System;

public class CutSceneStartTirgger : InteractionObject
{
    [SerializeField] private bool isPlayed = false;
    [SerializeField] private string cutSceneID; // = ID

    Action<string> startCutscene;

    public override void InteractionEvent()
    {
        if (isPlayed) return;

        startCutscene = (ID) => CutSceneManager.Inst.StartCutScene(ID); // ID = cutSceneID

        startCutscene(cutSceneID);
        isPlayed = true;

        gameObject.SetActive(false);
    }
}
