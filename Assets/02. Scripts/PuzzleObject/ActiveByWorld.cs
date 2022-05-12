using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveByWorld : MonoBehaviour
{
    public WorldType activeWorld;
    private SpriteRenderer spriteRenderer;
    new private Collider2D collider;
    private GameManager gm;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        bool isActiveWorld = (activeWorld == gm.WorldType);
 
            spriteRenderer.enabled = isActiveWorld;
            collider.enabled = isActiveWorld;
        
    }
}
