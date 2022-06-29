using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletWater : MonoBehaviour
{

    public GameObject waterYes;
    public GameObject waterNo;

    public void water()
    {
        
        waterNo.SetActive(true);
        waterYes.SetActive(false);
    }

}
