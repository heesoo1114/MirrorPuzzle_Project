using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : ToiletObjectManager
{
    [SerializeField] private float waitTime = 2f;
    
    public override void InteractionEvent()
    {
        if (isCheck) return;
        interect?.Invoke();
        StartCoroutine(DelayText());
        isCheck = true;
    }

    SpriteRenderer _spriteRenderer;

    private bool isBlue = true;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ColorChange()
    {
        if(isBlue == false)
        {
            _spriteRenderer.color = Color.white;
            isBlue = true;
        }
        else if(isBlue == true)
        {
            _spriteRenderer.color = Color.green;
            isBlue = false;
        }
        
    }

    private IEnumerator DelayText()
    {
        yield return new WaitForSeconds(waitTime);
        string text = GameManager.Inst.FindTextData(_textDataID);

        if (text.CompareTo("") == 0 || text == null) yield return null;
        GameManager.Inst.UI.ActiveTextPanal(text);
    }

}
