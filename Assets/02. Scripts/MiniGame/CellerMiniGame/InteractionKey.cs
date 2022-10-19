using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionKey : InteractionObject
{
    public UnityEvent GetKeyEvent;
    bool isPlaying;

    public override void InteractionEvent()
    {
        GetKeyEvent?.Invoke();
        InventorySystem.Inst.AddItem("10");

        CutSceneManager.Inst.StartCutScene("INVENTORY");
        Destroy(gameObject);

        GetKeyEvent.AddListener(() => { isPlaying = true; });

        if(isPlaying)
        {
            PlayerPrefs.SetInt("InteractionKey", 1);
        }
        else
        {
            PlayerPrefs.SetInt("InteractionKey", 0);
        }

        isPlaying = (PlayerPrefs.GetInt("InteractionKey") == 1);
    }
}
