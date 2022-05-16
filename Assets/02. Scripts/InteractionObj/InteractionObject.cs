using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    [SerializeField] protected string _textDataID;

    public virtual void InteractionEvent()
    {
        string text = GameManager.Inst.FindTextData(_textDataID);

        if (text.CompareTo("") == 0 || text == null) return;
        GameManager.Inst.UI.ActiveTextPanal(text);
    }

    public virtual void ExitInteraction()
    {
        GameManager.Inst.UI.ActiveTextPanal();
    }

}
