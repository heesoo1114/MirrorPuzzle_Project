using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class DishCreate : MonoBehaviour
{
    private int dishCkeck;
    private int spawnCnt;

    [SerializeField] private Dish[] dishTemp;
    [SerializeField] private int maxSpawnCnt;
    [SerializeField] private Vector2 maxPos;
    [SerializeField] private Vector2 minPos;
    [SerializeField] private TextMeshProUGUI success;
    [SerializeField] private Image background;
    [SerializeField] private Transform holder;

    public UnityEvent OnGameClear;
    private List<Dish> dishs = new List<Dish>();

    public void StartGame()
    {
        gameObject.SetActive(true);
        background.gameObject.SetActive(true);
        holder.gameObject.SetActive(true);

        spawnCnt = Random.Range(1, maxSpawnCnt);
        for(int i = 0; i < spawnCnt; i++)
        {
            //Dish dish = Instantiate(dishTemp, dishTemp.transform.parent);

            RandomSpawn();

            //dish.transform.localPosition = pos;
        }
    }

    void RandomSpawn()
    {
        Vector2 pos = Vector2.zero;
        pos.x = Random.Range(minPos.x, maxPos.x);
        pos.y = Random.Range(minPos.y, maxPos.y);

        int randomIndex = Random.Range(1, dishTemp.Length);
        Dish selectedPre = dishTemp[randomIndex];

        Dish dish = Instantiate(selectedPre, selectedPre.transform.parent);
        dish.OnDishClear += DishClear;
        dish.gameObject.SetActive(true);

        dish.transform.localPosition = pos;

        dishs.Add(dish);
    }

    void DishClear(Transform dish)
    {
        dish.transform.SetParent(holder);

        dishCkeck++;

        if(dishCkeck >= spawnCnt)
        {
            OnGameClear.Invoke();
            StartCoroutine(Clear());
        }
    }

    IEnumerator Clear()
    {
        success.gameObject.SetActive(true);
        InventorySystem.Inst.AddItem("BEDROOMKEY");
        yield return new WaitForSeconds(1f);

        foreach(Dish dish in dishs)
        {
            Destroy(dish);
        }
        dishs.Clear();


        success.gameObject.SetActive(false);
        holder.gameObject.SetActive(false);
        background.gameObject.SetActive(false);

        GameManager.Inst.ChangeGameState(EGameState.Game);

        gameObject.SetActive(false);
    }
}
