using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BigBrotherRoomKey : InteractionObject
{
    [SerializeField] private Vector3 _dropPos;

    private bool _isFallen;

    [SerializeField] private GameObject letter;

    public override void InteractionEvent()
    {
        InventorySystem.Inst.AddItem("SBROOMKEY");
        Destroy(gameObject);
    }

    public void Falling()
    {
        if (_isFallen) return;

        _isFallen = true;
        letter.gameObject.SetActive(true);

        transform.DOLocalMove(_dropPos, 0.5f);
    }
}
