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
            if(collision.transform.position.y > transform.position.y) // 플레이어가 물체 뒤(위)에 있다면
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
