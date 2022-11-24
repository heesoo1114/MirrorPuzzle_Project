using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DragAndDrop : MonoBehaviour
{
    private Vector2 originPos;
    private Board board;

    private Vector3 selectedSize = new Vector3(1,1,1);
    private Vector3 originSize;

    private void Start()
    {
        originPos = transform.position;
        board = transform.parent.parent.Find("Background").GetComponent<Board>();

        originSize = transform.localScale;
    }

    private void OnMouseDrag()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;

        transform.localScale = selectedSize;
    }

    private void OnMouseUp()
    {
        if (!PutDown())
        {
            transform.localScale = originSize;
        }
    }

    private bool PutDown()
    {
        Vector2[] blockPos = new Vector2[transform.childCount];
        int i = 0;

        foreach (Transform child in transform)
        {
            RaycastHit2D col = Physics2D.Raycast(child.position, transform.forward, 10f, 1 << 9);

            if (col == false)
            {
                transform.position = originPos;

                return false;
            }
        }

        foreach (Transform child in transform)
        {
            RaycastHit2D col = Physics2D.Raycast(child.position, transform.forward, 10f, 1 << 9);

            child.transform.position = new Vector2((int)col.transform.position.x, (int)col.transform.position.y);

            blockPos[i] = child.position;

            board.SetGridArea(blockPos[i]);

            i++;
        }

        return true;
    }
}
