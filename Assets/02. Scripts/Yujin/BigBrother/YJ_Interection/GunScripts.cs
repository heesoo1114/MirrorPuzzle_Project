using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScripts : InteractionObject
{
    public override void InteractionEvent()
    {
        base.InteractionEvent();

        StartCoroutine("GetNorealGun");
    }

    IEnumerator GetNorealGun()
    {
        yield return new WaitForSeconds(2.3f);

        InventorySystem.Inst.AddItem("BB_NotRealGun");
        gameObject.SetActive(false);
    }
}
