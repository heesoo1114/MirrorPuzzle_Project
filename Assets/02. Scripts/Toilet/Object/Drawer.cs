using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{

    public GameObject open;
    public GameObject close;
    public GameObject letter;  // 인벤토리 추가, 아이템을 사용했을 때 UI를 띄워서 편지 내용 보여주기 기능 추가

    // private bool isClose = false; 

    public void OpenDrawer()
    {
            open.SetActive(false);
            letter.SetActive(true);
            close.SetActive(true);
    }

}
