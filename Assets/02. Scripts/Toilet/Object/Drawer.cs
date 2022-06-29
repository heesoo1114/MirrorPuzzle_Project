using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : MonoBehaviour
{

    public GameObject open;
    public GameObject close;

    private bool isClose = false; 

    public void OpenDrawer()
    {

        //open.SetActive(!isClose);
        //close.SetActive(isClose);
        //isClose = !isClose;

        if (isClose == true)
        {
            open.SetActive(true);
            close.SetActive(false);
            isClose = false;
        }
        else if (isClose == false)
        {
            close.SetActive(true);
            open.SetActive(false);
            isClose = true;
        }

    }

}
