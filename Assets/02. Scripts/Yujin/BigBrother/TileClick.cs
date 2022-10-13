using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
using Cinemachine.Utility;

public class TileClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image emptyEmage;

    private Transform clickButtonTransform;

    private void Start()
    {
        clickButtonTransform = GetComponent<Transform>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Vector2.Distance(emptyEmage.gameObject.transform.position, clickButtonTransform.position) <= 1.5f)
        {
            Vector2 changeTransform = emptyEmage.gameObject.transform.position;

            emptyEmage.gameObject.transform.DOMove(clickButtonTransform.position, .1f); 
            clickButtonTransform.DOMove(changeTransform, .1f);
            //¼­·Î ¹Ù²ãÁÜ (swap)

        }
    }
}


