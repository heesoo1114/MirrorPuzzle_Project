using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tup : ToiletObjectManager
{

    public GameObject YesWater;
    public GameObject Nowater;
    public GameObject key;  // �κ��丮, ȭ��� �� ���� ���� ��� �߰�

    public bool isAction = false;
    public bool isNow = false;

    public override void InteractionEvent()
    {
        interect?.Invoke();
        StartCoroutine(NoneText());
    }

    public void waterOn()
    {
        YesWater.SetActive(false);
        Nowater.SetActive(true);
        key.SetActive(true);
        isAction = true;
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
            GameManager.Inst.UI.ActiveTextPanal(text);
        }
        else if (isNow == true)
        {
            string text = GameManager.Inst.FindTextData(_textDataID = "Tub_Now");

            if (text.CompareTo("") == 0 || text == null) yield return null;
            GameManager.Inst.UI.ActiveTextPanal(text);
        }
        yield return null;
    }

}
