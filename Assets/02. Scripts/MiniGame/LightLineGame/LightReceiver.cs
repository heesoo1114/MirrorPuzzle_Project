using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightReceiver : MonoBehaviour
{
    [SerializeField]
    private LightLineGameManager lightLineGameManager = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lightLineGameManager.GameEnd();    
    }
}
