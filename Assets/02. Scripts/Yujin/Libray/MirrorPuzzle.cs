using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MirrorPuzzle : InteractionObject
{
    [SerializeField]
    private Image aStampImage;
    [SerializeField]
    private Image bGoldImage;
    [SerializeField]
    private Image cBookImage;


    public override void InteractionEvent()
    {
        if (InventorySystem.Inst.equipItemDataID == "Library_A_Stamp")
        {
            aStampImage.gameObject.SetActive(true);
        }
        else if (InventorySystem.Inst.equipItemDataID == "Library_B_GoldBar")
        {
            bGoldImage.gameObject.SetActive(true);
        }
        else if (InventorySystem.Inst.equipItemDataID == "Library_C_Book")
        {
            cBookImage.gameObject.SetActive(true);
        }
    }
}
