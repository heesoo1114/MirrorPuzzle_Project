using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraPuzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject Film_spr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
         Film_spr.gameObject.SetActive(true);
    }

}
