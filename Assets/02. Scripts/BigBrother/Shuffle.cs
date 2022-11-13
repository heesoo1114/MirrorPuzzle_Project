using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    [SerializeField]
    private TileClick[] tiles;

    private Vector3[] tilesTransform;

    private void Start()
    {
        EventManager.StartListening("Swap", ClearCheck);
    }

    void OnEnable()
    {
        TileShuffle();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Debug.Log("cheat");
            for (int i = 0; i < tiles.Length; i++)
            {
                
            }
        }
    }

    void TileShuffle()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            Vector3 lastTilesPos = tiles[i].transform.position;
            int randomIdx = Random.Range(0, tiles.Length);
            tiles[i].transform.position = tiles[randomIdx].transform.position;
            tiles[randomIdx].transform.position = lastTilesPos;
        }
    }

    void ClearCheck()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i].transform.position == tilesTransform[i])
            {
                if (i == tiles.Length - 1)
                {
                    break;
                }
                continue;
            }
            else
            {
                Debug.Log("no");
            }
        }
        print("yes");
    }
}
