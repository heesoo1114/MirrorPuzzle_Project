
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBox : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab;

    private const int BOX_COUNT = 5;

    private readonly Vector2 MIN_POSITION = new Vector2(-7.4f, - 4.5f);
    private readonly Vector2 MAX_POSITION = new Vector2(7.82f, 1.45f);

    private void Start()
    {
        Generate();
    }
    private void Generate()
    {
        for(int i = 0; i < BOX_COUNT; i++)
        {
            Instantiate(boxPrefab, GetRandomPosition() ,Quaternion.identity, transform);
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 position;
        position.x = Random.Range(MIN_POSITION.x, MAX_POSITION.x);
        position.y = Random.Range(MIN_POSITION.y, MAX_POSITION.y);

        return position;
    }
}
