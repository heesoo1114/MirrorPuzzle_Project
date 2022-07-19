using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractionKey : InteractionObject
{
    public UnityEvent GetKeyEvent;

    public override void InteractionEvent()
    {
        GetKeyEvent?.Invoke();

        Destroy(gameObject);
    }
}
