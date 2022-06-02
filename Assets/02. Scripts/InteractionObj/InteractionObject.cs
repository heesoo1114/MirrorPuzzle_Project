using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    [SerializeField] protected string _textDataID;

    protected void Awake()
    {
        if (gameObject.tag.CompareTo("Interaction") != 0)
        {
            Debug.LogError($"상호작용 오브젝트({name})의 태그가 Interaction으로 되어있지 않습니다.");
            gameObject.tag = "Interaction";
        }

        AwakeChild();
    }

    protected virtual void AwakeChild()
    {
    }

    public virtual void EnterInteraction()
    {

    }

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


