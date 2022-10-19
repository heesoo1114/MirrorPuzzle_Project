using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Celler : MonoBehaviour
{
    [SerializeField] private List<RoomObject> _puzzleObjList;

    private void Start()
    {
        EventManager.StartListening("ENTER_Celler", StartCutScene);

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
}
