using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class Lamp : InteractionObject
{
    [SerializeField] private Light2D _lampLight;

    public UnityEvent<bool> OnTriggerInteraction;

    private bool _isOn = false;

    public override void InteractionEvent()
    {
        _isOn = !_isOn;
        _lampLight.enabled = _isOn;
        OnTriggerInteraction?.Invoke(_isOn);
    }
}
