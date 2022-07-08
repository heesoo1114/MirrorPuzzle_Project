using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{

    public GameObject open;
    public GameObject close;
    public GameObject letter;  // �κ��丮 �߰�, �������� ������� �� UI�� ����� ���� ���� �����ֱ� ��� �߰�

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
