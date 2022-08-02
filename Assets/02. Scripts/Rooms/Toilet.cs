using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour
{
    [SerializeField] WarpZone _warpZone;

    private void Start()
    {
        EventManager.StartListening("ENTER_TOILET", StartToiletCutScene);
    }

    private void StartToiletCutScene()
    {
        CutSceneManager.Inst.StartCutScene("TOILET");
        _warpZone.isLock = true;
        _warpZone.lockMessage = "문이 잠겨 나갈 수가 없다.";

        EventManager.StopListening("ENTER_TOILET", StartToiletCutScene);
    }
}
