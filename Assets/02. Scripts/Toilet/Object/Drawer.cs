using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{

    public GameObject open;
    public GameObject close;
    public GameObject letter;  // �κ��丮 �߰�, �������� ������� �� UI�� ����� ���� ���� �����ֱ� ��� �߰�

    // private bool isClose = false; 

    public void OpenDrawer()
    {
            open.SetActive(false);
            letter.SetActive(true);
            close.SetActive(true);
    }

}
