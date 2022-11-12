using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionBrotherNote : InteractionObject
{
    public UnityEvent GetNoteEvent;
    bool isPlaying;

    private void Start()
    {
        EventManager.StartListening("START_CELLERCUTSCENE", ObjOn);
        isPlaying = (PlayerPrefs.GetInt("InteractionBrotherNote") == 1);
    }

    private void ObjOn()
    {
        gameObject.SetActive(true);
    }

    public override void InteractionEvent()
    {
        GetNoteEvent?.Invoke();
        InventorySystem.Inst.AddItem("20");

        GetNoteEvent.AddListener(() => { isPlaying = true; });

        if (isPlaying)
            PlayerPrefs.SetInt("InteractionBrotherNote", 1);
    }
}
