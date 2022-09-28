using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightNextStage : MonoBehaviour
{
    public UnityEvent ImmediatelyGameEndEvent = null;

    [SerializeField]
    private GameObject nextStageObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.transform.position = transform.position;
        ImmediatelyGameEndEvent?.Invoke();
        gameObject.transform.parent.gameObject.SetActive(false);
        nextStageObj.gameObject.SetActive(true);
    }
}
