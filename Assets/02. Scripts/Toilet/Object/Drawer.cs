using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : ToiletObjectManager
{

    public GameObject open;
    public GameObject close;
    public GameObject letter;  // 인벤토리 추가, 아이템을 사용했을 때 UI를 띄워서 편지 내용 보여주기 기능 추가

    public bool isAction = false;
    public bool isNow = false;

    public override void InteractionEvent()
    {
        interect?.Invoke();
        StartCoroutine(NoneText());
    }

    public void OpenDrawer()
    {
        open.SetActive(false);
        letter.SetActive(true);
        close.SetActive(true);
        isAction = true;
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
