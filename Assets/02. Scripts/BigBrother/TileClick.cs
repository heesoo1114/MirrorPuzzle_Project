using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class TileClick : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image emptyEmage;

    private Transform clickButtonTransform;
    private RectTransform _rectTransform;

    [SerializeField] private float _posX;
    [SerializeField] private float _posY;

    private void Start()
    {
        clickButtonTransform = GetComponent<Transform>();
        _rectTransform = GetComponent<RectTransform>();
        StartCoroutine(TransformRounds());
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Vector2.Distance(emptyEmage.gameObject.transform.position, clickButtonTransform.position) <= 2f)
        {
            Vector2 changeTransform = emptyEmage.gameObject.transform.position;

            emptyEmage.gameObject.transform.DOMove(clickButtonTransform.position, .1f); 
            clickButtonTransform.DOMove(changeTransform, .1f);
            
            EventManager.TriggerEvent("Swap");
        }
    }

    private IEnumerator TransformRounds()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            _posX = Mathf.Round(_rectTransform.localPosition.x);
            _posY = Mathf.Round(_rectTransform.localPosition.y);
            _rectTransform.localPosition = new Vector3(_posX, _posY);
        }
    }
}


