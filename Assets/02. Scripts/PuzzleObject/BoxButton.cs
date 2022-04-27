using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxButton : MonoBehaviour
{
    public WorldType activeWorld;
    private SpriteRenderer spriteRenderer;
    new private Collider2D collider;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if(activeWorld == GameManager.WorldType)
        {
            spriteRenderer.enabled = false;
            collider.enabled = true;
        }
        else
        {
            spriteRenderer.enabled = true;
            collider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            Debug.Log("²Ú ´©·ë~");
        }
    }
}
