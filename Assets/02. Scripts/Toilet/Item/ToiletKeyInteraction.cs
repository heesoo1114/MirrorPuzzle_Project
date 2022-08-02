using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToiletKeyInteraction : InteractionObject
{
    public UnityEvent AddKeyEvent;
    private BoxCollider2D _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponentInParent<BoxCollider2D>();   
    }

    public override void InteractionEvent()
    {
        AddKeyEvent?.Invoke();
        InventorySystem.Inst.AddItem("1114");
        GameManager.Inst.UI.ActiveTextPanal("øÂ¡∂¿« πŸ¥⁄ø° ≥Ï¿Ã Ωº ø≠ºË∞° ¿÷¥Ÿ.");
        StartCoroutine("DestroyKey");
    }

    IEnumerator DestroyKey()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        _boxCollider.enabled = true;
    }
}
