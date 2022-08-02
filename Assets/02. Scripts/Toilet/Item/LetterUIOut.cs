using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterUIOut : MonoBehaviour
{

    public GameObject letterUI;
    private bool isLetter = false;

    public void letterUITest()
    {
        if (isLetter == false && InventorySystem.Inst.equipItemDataID == "2065")
        {
            letterUI.SetActive(true);
            isLetter = true;
        }
        else if(isLetter == true && InventorySystem.Inst.equipItemDataID == "2065")
        {
            letterUI.SetActive(false);
            isLetter = false;
        }
    }
}
