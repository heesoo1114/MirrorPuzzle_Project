using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    public Transform playerTranform;
    private GameManager gameManager;

    private Vector2 targetPosition = new Vector2(-0.6f, -1.75f);

    private bool isFallingStart = false;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (isFallingStart)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, targetPosition , Time.deltaTime * 3f);
        }   
    }

    private void OnMouseDown()
    {
        if (Vector2.Distance(transform.position, playerTranform.transform.position) < 2f)
        {
            gameManager.UIManger.SetActiveLetter(true);
        }
        
    }

    public void Fallling()
    {
        isFallingStart = true;
    }
}
