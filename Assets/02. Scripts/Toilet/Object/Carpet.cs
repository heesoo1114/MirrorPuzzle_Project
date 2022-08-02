using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : ToiletObjectManager
{
    SpriteRenderer _spriteRenderer;

    public bool isAction = false;
    public bool isNow = false;

    public override void InteractionEvent()
    {
        interect?.Invoke();
        StartCoroutine(NoneText());
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void NowColorChange()
    {
        _spriteRenderer.color = Color.green;
        isAction = true;
    }

    public void MirrorColorChange()
    {
        _spriteRenderer.color = Color.white;
    }

    IEnumerator NoneText()
    {
        if (isAction == true)
        {
            string text = GameManager.Inst.FindTextData(_textDataID = "Carpet_Mirror");

            if (text.CompareTo("") == 0 || text == null) yield return null;
            GameManager.Inst.UI.ActiveTextPanal(text);
        }
        else if (isNow == true)
        {
            string text = GameManager.Inst.FindTextData(_textDataID = "Carpet_Now");

            if (text.CompareTo("") == 0 || text == null) yield return null;
            GameManager.Inst.UI.ActiveTextPanal(text);
        }
        yield return null;
    }

}
