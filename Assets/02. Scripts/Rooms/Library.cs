using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Library : MonoBehaviour
{
    private bool isLibraryCutscenePlayed = false; // +¿˙¿Â

    private void Start()
    {
        EventManager.StartListening("ENTER_Library", StartLibraryCutScene);
    }

    private void StartLibraryCutScene()
    {
        if (GameManager.Inst.WorldType == WorldType.RealWorld) return;
        if (isLibraryCutscenePlayed) return;

        CutSceneManager.Inst.StartCutScene("LIBRARY");

        EventManager.StopListening("ENTER_Library", StartLibraryCutScene);

        isLibraryCutscenePlayed = true;
    }
}
