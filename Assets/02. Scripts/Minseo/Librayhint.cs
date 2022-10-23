using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Librayhint : MonoBehaviour
{
    public void Hint()
    {
        WarpZone warp;

        GameManager.Inst.ChangeGameState(EGameState.UI);
        LetterUI.OpenLetter("M");
        InventorySystem.Inst.UseEquipItem();
    }
}
