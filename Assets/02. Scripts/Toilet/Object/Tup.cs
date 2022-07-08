using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tup : MonoBehaviour
{

    public GameObject YesWater;
    public GameObject Nowater;
    public GameObject key;  // 인벤토리, 화장실 문 열기 가능 기능 추가

    public void water()
    {

        YesWater.SetActive(false);
        Nowater.SetActive(true);
        key.SetActive(true);

    }

}
