using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tup : ToiletObjectManager
{
    private BoxCollider2D _boxCollider;

    public GameObject YesWater;
    public GameObject Nowater;
    public GameObject key;  // 인벤토리, 화장실 문 열기 가능 기능 추가 

    public bool isAction = false;
    public bool isNow = false;

    public override void InteractionEvent()
    {
        interect?.Invoke();
        StartCoroutine(NoneText());
    }

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    public void waterOn()
    {
        YesWater.SetActive(false);
        Nowater.SetActive(true);
        key.SetActive(true);
        isAction = true;
        _boxCollider.enabled = false;
    }

    public void waterOff()
    {
        Nowater.SetActive(false);
        YesWater.SetActive(true);
    }

    IEnumerator NoneText()
    {
        if (isAction == true)
        {
            string text = GameManager.Inst.FindTextData(_textDataID = "Tub_Mirror");

            if (text.CompareTo("") == 0 || text == null) yield return null;
            TextSystem.Inst.ActiveTextPanal(text);
        }
        else if (isNow == true)
        {
            string text = GameManager.Inst.FindTextData(_textDataID = "Tub_Now");

            if (text.CompareTo("") == 0 || text == null) yield return null;
            TextSystem.Inst.ActiveTextPanal(text);
        }
        yield return null;
    }

}
