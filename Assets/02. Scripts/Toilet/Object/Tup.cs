using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tup : MonoBehaviour
{

    public GameObject YesWater;
    public GameObject Nowater;
    public GameObject key;  // �κ��丮, ȭ��� �� ���� ���� ��� �߰�

    public void water()
    {

        YesWater.SetActive(false);
        Nowater.SetActive(true);
        key.SetActive(true);

    }

}
