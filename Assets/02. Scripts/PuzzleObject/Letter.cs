using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Letter : InteractionObject
{
    [SerializeField]
    [TextArea]
    private string _letterMessage;
    public override void InteractionEvent()
    {
        GameManager.Inst.UI.SetActiveLetter(_letterMessage);
    }
}
