using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    private Transform playerTranform;
    private GameManager gameManager;

    private void Start()
    {
        playerTranform = FindObjectOfType<PlayerMove>().transform;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnMouseDown()
    {
        if (Vector2.Distance(transform.position, playerTranform.transform.position) < 2f)
        {
            gameManager.UI.SetActiveLocker(true);
        }

    }
}
