using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class Dish : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] int defaultCnt;
    [SerializeField] int randnessCnt;
    [SerializeField] float mDistance;

    private Camera camera = null;
    private int cnt;
    private Vector2 mousePos;

    private int sum;
    private bool isMouseDown = false;
    private bool isMouseExit = false;
    private bool isMouseEnter = false;

    public Action OnDishClear;


    void Start()
    {
        sum = defaultCnt + Random.Range(-randnessCnt, randnessCnt);
        camera = Camera.main;
    }

    void Update()
    {
        if (isMouseDown == false) return;

        Vector2 currentPos = camera.ScreenToWorldPoint(Input.mousePosition);

        if(Vector2.Distance(mousePos, currentPos) >= mDistance)
        {
            mousePos = currentPos;/*현재의 포지션*/;

            if(isMouseEnter)
            {
                if(isMouseExit)
                {
                    isMouseEnter = false;
                }

                cnt++;

                if (cnt >= sum)
                {
                    OnDishClear?.Invoke(); 
                    Destroy(gameObject);
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(11);
        if (isMouseDown == true) return;
        isMouseDown = true;

        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isMouseDown == false) return;

        if(isMouseEnter == false)
        {
            isMouseEnter = true;
        }

        if (isMouseExit)
        {
            isMouseExit = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (isMouseDown == false) return;

        if(isMouseExit == false)
        {
            isMouseExit = true;
        }
    }
}
