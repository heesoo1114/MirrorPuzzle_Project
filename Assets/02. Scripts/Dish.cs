using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using Random = UnityEngine.Random;

public class Dish : MonoBehaviour
{
    public Action<Transform> OnDishClear;
    public UnityEvent OnWashDish;
    public UnityEvent OnCleanDish;

    void Start()
    {

    }

    void Update()
    {
   
    }
}
