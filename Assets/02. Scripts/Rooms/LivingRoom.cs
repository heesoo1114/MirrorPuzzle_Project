using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingRoom : MonoBehaviour
{
    [SerializeField] private WarpZone _hallWayWarpZone;

    private void Start()
    {
        InitWarpzone();
        EventManager.StartListening("ENTER_LivingRoom", SetWarpzones);
    }

    private void SetWarpzones()
    {
        if(_hallWayWarpZone.isLock)
        {
            if (InventorySystem.Inst.EqualsItem("LIBRARYKEY"))
            {
                _hallWayWarpZone.isLock = false;
                _hallWayWarpZone.lockMessage = "";
            }
        }

        else
        {
            EventManager.StopListening("ENTER_LivingRoom", SetWarpzones);
        }

    }

    private void InitWarpzone()
    {
        _hallWayWarpZone.isLock = true;
        _hallWayWarpZone.lockMessage = "2층으로 갈 이유는 아직 없는 것 같다.";
    }

}
