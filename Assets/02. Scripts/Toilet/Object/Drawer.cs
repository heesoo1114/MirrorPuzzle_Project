using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : ToiletObjectManager
{
    private BoxCollider2D _boxCollider;

    public GameObject open;
    public GameObject close;
    public GameObject letter;  // �κ��丮 �߰�, �������� ������� �� UI�� ����� ���� ���� �����ֱ� ��� �߰�

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

    public void OpenDrawer()
    {
        open.SetActive(false);
        letter.SetActive(true);
        close.SetActive(true);
        isAction = true;
        _boxCollider.enabled = false;
    }

    public void CloseDrawer()
    {
        open.SetActive(true);
        letter.SetActive(false);
        close.SetActive(false);
    }

    IEnumerator NoneText()
    {
        if (isAction == true)
        {
            string text = GameManager.Inst.FindTextData(_textDataID = "Drawer_Mirror");
            
            if (text.CompareTo("") == 0 || text == null) yield return null;
            GameManager.Inst.UI.ActiveTextPanal(text);
        }
        else if (isNow == true)
        {
            string text = GameManager.Inst.FindTextData(_textDataID = "Drawer_Now");

            if (text.CompareTo("") == 0 || text == null) yield return null;
            GameManager.Inst.UI.ActiveTextPanal(text);
        }
        yield return null;
    }
}
