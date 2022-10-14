using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    [SerializeField]
    private TileClick[] tiles;


    void OnEnable()
    {
        Debug.Log("TileShuffle");
        TileShuffle();
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
}
