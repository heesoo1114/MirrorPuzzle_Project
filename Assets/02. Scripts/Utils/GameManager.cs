using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private UIManager uiManager;
    public UIManager UIManger { get { return uiManager; } }
    public GameObject tileMapGrid;
    
    private void Awake()
    {
        uiManager = GetComponent<UIManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeWorld();
        }
    }

    private void ChangeWorld()
    {
        if (tileMapGrid.transform.localScale.x > 0f)
        {
            tileMapGrid.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else
        {
            tileMapGrid.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

}
