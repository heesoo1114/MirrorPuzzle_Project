using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TileClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image emptyEmage;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log(eventData.position);

    }
}
