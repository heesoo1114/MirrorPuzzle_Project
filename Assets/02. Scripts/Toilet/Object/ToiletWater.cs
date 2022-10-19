using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletWater : ToiletObjectManager
{

    public GameObject waterYes;
    public GameObject waterNo;

    public bool isAction = false;
    public bool isNow = false;

    public override void InteractionEvent()
    {
        interect?.Invoke();
        StartCoroutine(NoneText());
    }

    public void water()
    {
        waterNo.SetActive(true);
        waterYes.SetActive(false);
        isAction = true;
    }

    public void noWater()
    {
        waterNo.SetActive(false);
        waterYes.SetActive(true); 
    }

    IEnumerator NoneText()
    {
        if (isAction == true)
        {
            string text = GameManager.Inst.FindTextData(_textDataID = "Toilet_Mirror");

            if (text.CompareTo("") == 0 || text == null) yield return null;
            TextSystem.Inst.ActiveTextPanal(text);
        }
        else if (isNow == true)
        {
            string text = GameManager.Inst.FindTextData(_textDataID = "Toilet_Now");

            if (text.CompareTo("") == 0 || text == null) yield return null;
            TextSystem.Inst.ActiveTextPanal(text);
        }
        yield return null;
    }
}
