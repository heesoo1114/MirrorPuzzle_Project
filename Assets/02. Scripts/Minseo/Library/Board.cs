using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPuzzle;
    [SerializeField]
    private GameObject hintImage;

    public GameObject grid;

    public int[,] arr =
        {
            { 0, 1, 1, 1, 0, 0 },
            { 1, 1, 1, 1, 0, 0 },
            { 0 ,1, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1 },
        };


    private void Start()
    {
        for (int i = 0; i < arr.GetLength(0); i++)//y°ª
        {
            for (int j = 0; j < arr.GetLength(1); j++)//x°ª
            {
                Debug.Log($"[{i}, {j}] : {arr[i, j]}");
                if (arr[i, j] == 1)
                {
                    GameObject _grid = Instantiate(grid, new Vector2(j + 48, -i + 39), Quaternion.identity);
                    _grid.transform.parent = transform;  
                }
            }
        }
    }

    public void SetGridArea(Vector3 blockPos)
    {
        int x = (int)blockPos.x - 48;
        int y = (int)blockPos.y - 39;

        arr[-y, x] = 0;

        if (CheckFullGrid())
        {
            blockPuzzle.gameObject.SetActive(false);
            hintImage.gameObject.SetActive(true);
        }
    }

    private bool CheckFullGrid()
    {

        foreach (int value in arr)
        {
            if (value == 1)
            {
                return false;
            }
        }

        return true;
    }
}
