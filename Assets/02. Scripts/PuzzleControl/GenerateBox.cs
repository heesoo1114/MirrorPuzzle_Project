
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateBox : MonoBehaviour
{
    [SerializeField]
    private GameObject boxPrefab;

    private const int boxCount = 5;

    private readonly Vector2 minPosition = new Vector2(-7.4f, - 4.5f);
    private readonly Vector2 maxPosition = new Vector2(7.82f, 1.45f);

    private void Start()
    {
        Generate();
    }
    private void Generate()
    {
        for(int i = 0; i < boxCount; i++)
        {
            Instantiate(boxPrefab, GetRandomPosition() ,Quaternion.identity, transform);
        }
    }

    private Vector2 GetRandomPosition()
    {
        Vector2 position;
        position.x = Random.Range(minPosition.x, maxPosition.x);
        position.y = Random.Range(minPosition.y, maxPosition.y);

        return position;
    }
}
