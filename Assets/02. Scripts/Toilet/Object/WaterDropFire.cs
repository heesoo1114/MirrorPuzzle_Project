using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropFire : MonoBehaviour
{

    public GameObject waterPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaterDrop");
    }

    IEnumerator WaterDrop()
    {
        for(int i = 0; i < 3; i++)
        {
            while(true)
            {
                Instantiate(waterPrefabs, gameObject.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
        }
        yield return new WaitForSeconds(1f);
    }

}
