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
            StringBuilder str = new StringBuilder(_textDataID);
            str.Append("_REALWORLD");
            _textDataID = str.ToString();
        }

        else
        {
            StringBuilder str = new StringBuilder(_textDataID);
            str.Append(_canRead ? "_READ" : "_NOTREAD");
            _textDataID = str.ToString();
        }
       
    }
}
