using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetObject : MonoBehaviour
{
    private readonly int maxCount = 3;
    private int count = 3;
    [SerializeField] private GameObject letter;
    [SerializeField] private Transform player;

    private void Start()
    {
        count = maxCount;
    }

    private void OnMouseUp()
    {
        if ((player.position - transform.position).magnitude > 7.3f) return;
        if (count == 0) return;
        count--;

        if (count == 0)
        {
            letter.gameObject.SetActive(true);
        }
    }
}
