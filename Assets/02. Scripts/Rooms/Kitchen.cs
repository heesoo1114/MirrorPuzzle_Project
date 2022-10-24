using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : MonoBehaviour
{
    [SerializeField] private List<WarpZone> _warpZoneList;
    [SerializeField] private List<RoomObject> _puzzleObjList;

    [SerializeField] private Collider2D _minigameStarter;

    private bool isKitchenCutScenePlayed = false; // +저장

    private void Start()
    {
        EventManager.StartListening("START_STARTCUTSCENE", () => SetIsLockWarpzone(true, RoomType.LivingRoom, "다시 한 번 생각해보자.."));
        EventManager.StartListening("ENTER_Kitchen", StartKitchenPuzzle);
        EventManager.StartListening("CLEAR_TOILET", StartMinigame);
    }

    private void StartKitchenPuzzle()
    {
        if (GameManager.Inst.WorldType == WorldType.MirrorWorld) // 거울세계로 가고 처음 부엌으로 들어갔을 때 컷신 재생
        {
            if (isKitchenCutScenePlayed) return;
            CutSceneManager.Inst.StartCutScene("KITCHEN");
            isKitchenCutScenePlayed = true;
        }

        _puzzleObjList.ForEach(x => x.Active(true));
        SetIsLockWarpzone(false, RoomType.LivingRoom);
        EventManager.StopListening("ENTER_Kitchen", StartKitchenPuzzle);
    }

    private void StartMinigame()
    {
        _minigameStarter.enabled = true;
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
