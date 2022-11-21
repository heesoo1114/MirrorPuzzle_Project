using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuffle : MonoBehaviour
{
    [SerializeField]
    private TileClick[] tiles;

    [SerializeField]
    private Vector3[] tilesTransform;

    private void Start()
    {
        EventManager.StartListening("Swap", ClearCheck);
    }

    void OnEnable()
    {
        TileTrSave();
    }

    private void Update()
    {
        // 개발자 디버깅용 치트 (슬라이더 퍼즐 깨는)
        /*if (Input.GetKeyDown(KeyCode.H))
        {
            InventorySystem.Inst.AddItem("HAND_MIRROR");
            Debug.Log("cheat");
            for (int i = 0; i < tiles.Length; i++)
            {
                tiles[i].GetComponent<RectTransform>().localPosition = tilesTransform[i];
            }
        }*/
    }

    private void TileTrSave()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            tilesTransform[i] = tiles[i].GetComponent<RectTransform>().localPosition;
        }
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

    void ClearCheck()
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tilesTransform[i] == tiles[i].GetComponent<RectTransform>().localPosition)
            {
                int lastTile = tiles.Length - 1;
                if (i == lastTile)
                {
                    EventManager.TriggerEvent("ClearPuzzle");
                }
                continue;
            }
            else
            {
                break;
            }
        }
    }
}
