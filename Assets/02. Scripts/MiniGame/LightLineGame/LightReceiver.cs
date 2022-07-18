using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightReceiver : MonoBehaviour
{
    public UnityEvent ImmediatelyGameEndEvent = null;
    private LightLineGameManager lightLineGameManager = null;

    private void Awake()
    {
        lightLineGameManager = GetComponentInParent<LightLineGameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = transform.position;
        ImmediatelyGameEndEvent?.Invoke();
        lightLineGameManager.GameEnd();    
    }
}
