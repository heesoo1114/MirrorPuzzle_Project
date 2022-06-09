using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    private Transform playerTranform;

    private void Start()
    {
        playerTranform = Define.PlayerTransform;
    }

    private void OnMouseDown()
    {
        if (Vector2.Distance(transform.position, playerTranform.transform.position) < 2f)
        {
            GameManager.Inst.UI.SetActiveLocker(true);
        }

    }
}
