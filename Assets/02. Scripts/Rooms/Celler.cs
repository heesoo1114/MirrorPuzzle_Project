using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celler : MonoBehaviour
{
    [SerializeField] private List<WarpZone> _warpZoneList;
    [SerializeField] private List<RoomObject> _puzzleObjList;

    private void Start()
    {
        EventManager.StartListening("ENTER_Celler", StartCutScene);
        EventManager.StartListening("START_STARTCUTSCENE", () => SetIsLockWarpzone(true, RoomType.Celler, "������ ��������. ������ �ֽ��� ������ ����! \n ����� �ְ���?"));
        EventManager.StartListening("END_INTRO2CUTSCENE", () => SetIsLockWarpzone(false, RoomType.Celler));
    }

    private void StartCellerPuzzle()
    {
        _puzzleObjList.ForEach(x => x.Active(true));
    }

    private void StartCutScene()
    {
        CutSceneManager.Inst.StartCutScene("CELLER");

        EventManager.StopListening("ENTER_Celler", StartCutScene);
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
