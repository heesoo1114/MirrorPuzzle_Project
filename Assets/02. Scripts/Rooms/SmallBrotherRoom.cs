using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBrotherRoom : MonoBehaviour
{
    private bool isSmallBrotheryCutscenePlayed = false; // +¿˙¿Â

    private void Start()
    {
        EventManager.StartListening("ENTER_SmallBrother", StartLibraryCutScene);
    }

    private void StartLibraryCutScene()
    {
        if (GameManager.Inst.WorldType == WorldType.RealWorld) return;
        if (isSmallBrotheryCutscenePlayed) return;

        CutSceneManager.Inst.StartCutScene("SMALLBROTHER");

        EventManager.StopListening("ENTER_SmallBrother", StartLibraryCutScene);

        isSmallBrotheryCutscenePlayed = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            CutSceneManager.Inst.StartCutScene("SMALLBROTHER");
        }
    }
}
