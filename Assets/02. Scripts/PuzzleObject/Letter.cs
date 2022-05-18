using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Letter : MonoBehaviour
{
    public Transform playerTranform;
    private GameManager gameManager;

    private Vector2 targetPosition = new Vector2(-0.6f, -1.75f);

    private bool isFallingStart = false;
    [SerializeField] private UnityEvent clickEvent;
    
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
            //gameManager.UIManger.SetActiveLetter(true);
            clickEvent.Invoke();
        }
        
    }

    public void Fallling()
    {
        isFallingStart = true;
    }
}
