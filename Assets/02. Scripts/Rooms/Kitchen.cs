using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    [SerializeField] private List<WarpZone> _warpZoneList;

    private void Start()
    {
        EventManager.StartListening("START_STARTCUTSCENE", () => SetIsLockWarpzone(true, RoomType.LivingRoom, "���� �� �������� ���� �ʾҾ�!"));
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
