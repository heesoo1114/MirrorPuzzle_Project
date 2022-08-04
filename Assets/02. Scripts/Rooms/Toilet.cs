using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour
{
    private void Start()
    {
        EventManager.StartListening("ENTER_Toilet", StartToiletCutScene);
    }

    private void StartToiletCutScene()
    {
        CutSceneManager.Inst.StartCutScene("TOILET");
        
        EventManager.StopListening("ENTER_TOILET", StartToiletCutScene);
    }
}
