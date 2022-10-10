using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surap : ToiletObjectManager
{

    public GameObject crackFL;
    public GameObject whollyFL;

    public bool isAction = false;
    public bool isNow = false;

    public override void InteractionEvent()
    {
        interect?.Invoke();
        StartCoroutine(NoneText());
    }

    public void crack()
    {
        crackFL.SetActive(true);
        whollyFL.SetActive(false);
        isAction = true;
    }

    public void wholly()
    {
        crackFL.SetActive(false);
        whollyFL.SetActive(true);
    }

    IEnumerator NoneText()
    {
        if (isAction == true)
        {
            string text = GameManager.Inst.FindTextData(_textDataID = "Flower_Mirror");

            if (text.CompareTo("") == 0 || text == null) yield return null;
            GameManager.Inst.UI.ActiveTextPanal(text);
        }
        else if (isNow == true)
        {
            string text = GameManager.Inst.FindTextData(_textDataID = "Flower_Now");

            if (text.CompareTo("") == 0 || text == null) yield return null;
            GameManager.Inst.UI.ActiveTextPanal(text);
        }
        yield return null;
    }
}
