using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletWater : MonoBehaviour
{

    public GameObject waterYes;
    public GameObject waterNo;
    // public GameObject WaterPosition;

    public void water()
    {
        
        waterNo.SetActive(true);
        waterYes.SetActive(false);

        // StartCoroutine("heesoo");

    }

/*    IEnumerator heesoo()
    {
        WaterPosition.SetActive(true);
        yield return new WaitForSeconds(5f);
        WaterPosition.SetActive(false);
    }
*/
}
