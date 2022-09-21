using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class DishCreate : MonoBehaviour
{
    [SerializeField] private Dish[] dishTemp;
    [SerializeField] private int maxSpawnCnt;
    [SerializeField] private TextMeshProUGUI success;
    [SerializeField] private Image background;

    public UnityEvent OnGameClear;
    private List<Dish> dishs = new List<Dish>();

    public void StartGame()
    {
        gameObject.SetActive(true);
        background.gameObject.SetActive(true);
    }

    void DishClear(Transform dish)
    {
        OnGameClear.Invoke();
        StartCoroutine(Clear());
    }

    IEnumerator Clear()
    {
        success.gameObject.SetActive(true);
        InventorySystem.Inst.AddItem("BEDROOMKEY");
        yield return new WaitForSeconds(1f);

        foreach (Dish dish in dishs)
        {
            Destroy(dish);
        }
        dishs.Clear();

        success.gameObject.SetActive(false);
        background.gameObject.SetActive(false);

        gameObject.SetActive(false);
    }
}
