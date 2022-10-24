using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToiletLetterInteraction : InteractionObject
{
    public UnityEvent LetterEvent;
    private BoxCollider2D _boxCollider;
    bool isPlaying;

    private void Start()
    {
        _boxCollider = GetComponentInParent<BoxCollider2D>();
    }

    public override void InteractionEvent()
    {
        InventorySystem.Inst.AddItem("2065");
        TextSystem.Inst.ActiveTextPanal("�ϴû� ������ ��� ������ �ִ�.");
        StartCoroutine("DestroyLetter");

        LetterEvent.AddListener(() => { isPlaying = true; });

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

    IEnumerator DestroyLetter()
    {
        yield return new WaitForSeconds(2f);
        LetterEvent?.Invoke();
        gameObject.SetActive(false);
    }
}

    

    
