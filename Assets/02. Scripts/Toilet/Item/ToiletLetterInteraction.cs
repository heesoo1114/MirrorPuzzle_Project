using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToiletLetterInteraction : InteractionObject
{
    public UnityEvent LetterEvent;
    private BoxCollider2D _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponentInParent<BoxCollider2D>();
    }

    public override void InteractionEvent()
    {
        InventorySystem.Inst.AddItem("2065");
        TextSystem.Inst.ActiveTextPanal("하늘색 봉투에 담긴 편지가 있다.");
        StartCoroutine("DestroyLetter");
    }

    IEnumerator DestroyLetter()
    {
        yield return new WaitForSeconds(2f);
        LetterEvent?.Invoke();
        gameObject.SetActive(false);
    }
}
