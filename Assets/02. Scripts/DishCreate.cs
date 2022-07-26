using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DishCreate : MonoBehaviour
{
    public Dish dishTemp;
    private int gameClear;
    private int dishCkeck;
    private int spawnCnt;

    [SerializeField] private int maxSpawnCnt;
    [SerializeField] private Vector2 maxPos;
    [SerializeField] private Vector2 minPos;

    void Start()
    {
        spawnCnt = Random.Range(1, maxSpawnCnt);
        for(int i = 0; i < spawnCnt; i++)
        {
            Dish dish = Instantiate(dishTemp, dishTemp.transform.parent);
            dish.OnDishClear += AddDishCnt;
            dish.gameObject.SetActive(true);
            
            Vector2 pos = Vector2.zero;
            pos.x = Random.Range(minPos.x, maxPos.x);
            pos.y = Random.Range(minPos.y, maxPos.y);

            dish.transform.localPosition = pos;
        }
    }

    void AddDishCnt()
    {
        dishCkeck++;

        if(dishCkeck >= spawnCnt)
        {
            Debug.Log("Clear");
        }
    }
}
