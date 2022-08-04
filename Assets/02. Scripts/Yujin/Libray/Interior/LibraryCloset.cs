using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryCloset : InteractionObject
{
    int cnt = 0;

    public override void InteractionEvent()
    {
        if(cnt <= 2)
        {
            transform.GetChild(cnt).gameObject.SetActive(false);

            if(cnt == 0)
                InventorySystem.Inst.AddItem("Library_A_Stamp");
            else if (cnt == 1) 
                InventorySystem.Inst.AddItem("Library_B_GoldBar");
            else if (cnt == 2)
                InventorySystem.Inst.AddItem("Library_C_Book");

            Debug.Log(cnt);
            cnt++;
        }
        else
        {
            base.InteractionEvent();
        }
    }
}
