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
    }

    public override void InteractionEvent()
    {
        AddKeyEvent?.Invoke();
        InventorySystem.Inst.AddItem("1114");
        TextSystem.Inst.ActiveTextPanal("¿åÁ¶ÀÇ ¹Ù´Ú¿¡ ³ìÀÌ ½¼ ¿­¼è°¡ ÀÖ´Ù.");
        StartCoroutine("DestroyKey");

        AddKeyEvent.AddListener(() => { isPlaying = true; });

        if (isPlaying)
        {
            PlayerPrefs.SetInt("InteractionKey", 1);
        }
        else
        {
            PlayerPrefs.SetInt("InteractionKey", 0);
        }

        isPlaying = (PlayerPrefs.GetInt("InteractionKey") == 1);
    }

    IEnumerator DestroyKey()
    {
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
        _boxCollider.enabled = true;
    }
}
