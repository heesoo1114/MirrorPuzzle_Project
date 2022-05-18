using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class Window : InteractionObject
{
    [SerializeField] private float[] _lightPowerInfos;
    [SerializeField] private Light2D _outsideLight;

    public UnityEvent OnTriggerEvent;

    public override void InteractionEvent()
    {
        OnTriggerEvent?.Invoke();
    }

    public override void ExitInteraction()
    {
        base.ExitInteraction();
    }

    public void ChangeLightPower(int idx)
    {
        _outsideLight.transform.localScale = new Vector3(_lightPowerInfos[idx], 1f, 1f);
    }

    public void TurnLight(bool turnedOn)
    {
        _outsideLight.enabled = turnedOn;
    }
}
