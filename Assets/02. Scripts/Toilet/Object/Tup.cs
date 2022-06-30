using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tup : MonoBehaviour
{

    public GameObject YesWater;
    public GameObject Nowater;

    public void water()
    {

        YesWater.SetActive(false);
        Nowater.SetActive(true);

    }

}
