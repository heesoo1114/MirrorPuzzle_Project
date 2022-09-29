using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookAtGame : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            if(collision.transform.position.y > transform.position.y) // �÷��̾ ��ü ��(��)�� �ִٸ�
            {
                spriteRenderer.sortingLayerName = "ForeObject";
            }
            else if(collision.transform.position.y < transform.position.y)
            {
                spriteRenderer.sortingLayerName = "BackObject";
            }
        }
    }

}
