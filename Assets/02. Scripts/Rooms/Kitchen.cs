using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    [SerializeField] private List<WarpZone> _warpZoneList;

    private void Start()
    {
        EventManager.StartListening("START_STARTCUTSCENE", () => SetIsLockWarpzone(true, RoomType.LivingRoom, "형은 이 방향으로 가지 않았어!"));
    }

    public void SetIsLockWarpzone(bool value, RoomType type, string lockMessage = "")
    {
        WarpZone warpZone = _warpZoneList.Find(x => x.targetRoom == type);

        if (warpZone != null)
        {
            warpZone.isLock = value;
            warpZone.lockMessage = lockMessage;
        }
    }
}
