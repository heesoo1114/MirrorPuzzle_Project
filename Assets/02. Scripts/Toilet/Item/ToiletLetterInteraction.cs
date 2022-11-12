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
        isPlaying = (PlayerPrefs.GetInt("ToiletLetterInteraction") == 1);
    }

    public override void InteractionEvent()
    {
        InventorySystem.Inst.AddItem("2065");
        TextSystem.Inst.ActiveTextPanal("하늘색 봉투에 담긴 편지가 있다.");
        StartCoroutine("DestroyLetter");

        LetterEvent.AddListener(() => { isPlaying = true; });

        if (isPlaying)
            PlayerPrefs.SetInt("ToiletLetterInteraction", 1);
    }

    IEnumerator DestroyLetter()
    {
        yield return new WaitForSeconds(2f);
        LetterEvent?.Invoke();
        gameObject.SetActive(false);
    }
}

    

    
