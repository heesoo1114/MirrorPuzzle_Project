using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToiletObjectManager : InteractionObject
{
    public UnityEvent interect;

    protected bool isCheck = false;

    public override void InteractionEvent()
    {
        //if (isCheck) return;
        base.InteractionEvent();
        
        interect?.Invoke();
        //isCheck = true;
    }
}
