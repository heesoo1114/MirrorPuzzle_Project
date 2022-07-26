using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletWorldMove : MonoBehaviour
{

    public GameObject NowWorld;
    public GameObject MirrorWorld;


    public void MirrorOff() // 거울세계 off, 현실세계 on
    {
        NowWorld.SetActive(true);
        MirrorWorld.SetActive(false);
    }

    public void MirrorOn() // 거울세계 on, 현실세계 off
    {
        NowWorld.SetActive(false);
        MirrorWorld.SetActive(true);
    }

}
