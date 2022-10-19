using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletWorldMove : MonoBehaviour
{

    public GameObject NowWorld;
    public GameObject MirrorWorld;


    public void MirrorOff() // �ſ＼�� off, ���Ǽ��� on
    {
        NowWorld.SetActive(true);
        MirrorWorld.SetActive(false);
    }

    public void MirrorOn() // �ſ＼�� on, ���Ǽ��� off
    {
        NowWorld.SetActive(false);
        MirrorWorld.SetActive(true);
    }

}
