using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SmallbrotherRoomkey : InteractionObject
{
    [SerializeField] private Vector3 _dropPos;

    private bool _isFallen;

    [SerializeField] private GameObject letter;

    public override void InteractionEvent()
    {
        InventorySystem.Inst.AddItem("BBROOMKEY");

        TextSystem.Inst.ActiveTextPanal("그런데 아까 사진 어디서 많이 봤던 얼굴인데? \n 에이, 모르겠다.");

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
