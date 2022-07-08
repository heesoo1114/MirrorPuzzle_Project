using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{

    public GameObject open;
    public GameObject close;
    public GameObject letter;  // 인벤토리 추가, 아이템을 사용했을 때 UI를 띄워서 편지 내용 보여주기 기능 추가

    private bool isClose = false; 

    public void OpenDrawer()
    {

        //open.SetActive(!isClose);
        //close.SetActive(isClose);
        //isClose = !isClose;



        if (isClose == true)
        {
            open.SetActive(true);
            letter.SetActive(false);
            close.SetActive(false);

            isClose = false;
        }
        else if (isClose == false)
        {
            close.SetActive(true);
            letter.SetActive(true);
            open.SetActive(false);
            isClose = true;
        }

    }

}
