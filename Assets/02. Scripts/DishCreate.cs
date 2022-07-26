using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DishCreate : MonoBehaviour
{
    public GameObject dish;
    private int gameClear;
    private int dishCkeck;
    private int spawnCnt;
    private int posX;
    private int posY;
    private int posRandom;

    void Start()
    {
        posX = Random.Range(-750, 750);
        posY = Random.Range(-277, 277);

        posRandom = new Vector2(posX, posY);

        dish = Instantiate(gameObject, gameObject.transform.parent);
        spawnCnt = Random.Range(posX, posY);
    }

    void Update()
    {
        if (dishCkeck > 5)
        {
            Debug.Log("success");
        }
    }
}
