using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Book : InteractionObject
{
    private bool _canRead;

    public void CanRead(bool value)
    {
        _canRead = value;
    }

    public override void InteractionEvent()
    {
        string oirginID = _textDataID;

        if(GameManager.Inst.WorldType == WorldType.RealWorld)
        {
            StringBuilder str = new StringBuilder(oirginID);
            str.Append("_REALWORLD");
            oirginID = str.ToString();
        }

        else
        {
            StringBuilder str = new StringBuilder(oirginID);
            str.Append(_canRead ? "_READ" : "_NOTREAD");
            oirginID = str.ToString();
        }

        string text = GameManager.Inst.FindTextData(oirginID);

        if (text.CompareTo("") == 0 || text == null) return;
        GameManager.Inst.UI.ActiveTextPanal(text);
    }
}
