using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToiletKeyInteraction : InteractionObject
{
    public UnityEvent AddKeyEvent;
    private BoxCollider2D _boxCollider;
    bool isPlaying;

    private void Start()
    {
        _boxCollider = GetComponentInParent<BoxCollider2D>();   
        isPlaying = (PlayerPrefs.GetInt("ToiletKeyInteraction") == 1);
    }

    public override void InteractionEvent()
    {
        AddKeyEvent?.Invoke();
        InventorySystem.Inst.AddItem("1114");
        TextSystem.Inst.ActiveTextPanal("������ �ٴڿ� ���� �� ���谡 �ִ�.");
        StartCoroutine("DestroyKey");

        AddKeyEvent.AddListener(() => { isPlaying = true; });

        if (isPlaying)
            PlayerPrefs.SetInt("ToiletKeyInteraction", 1);
    }

    IEnumerator DestroyKey()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        _boxCollider.enabled = true;
    }
}
