using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveByWorld : MonoBehaviour
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
        bool isActiveWorld = (activeWorld == GameManager.WorldType);
 
            spriteRenderer.enabled = isActiveWorld;
            collider.enabled = isActiveWorld;
        
    }
}
