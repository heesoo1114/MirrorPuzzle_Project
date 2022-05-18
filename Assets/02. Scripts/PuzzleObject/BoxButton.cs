using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxButton : MonoBehaviour
{
    public WorldType activeWorld;
    private SpriteRenderer spriteRenderer;
    new private Collider2D collider;
    private GameObject lightObject;
    private GameManager gm;
    [SerializeField] private Letter key;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        gm = FindObjectOfType<GameManager>();

        if (transform.childCount > 0)
        {
            lightObject = transform.GetChild(0).gameObject;
        }
    }

    private void Update()
    {
        if (activeWorld == gm.WorldType)
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = false;
                lightObject?.gameObject.SetActive(false);
            }

            if (collider != null)
                collider.enabled = true;
        }
        else
        {
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = true;
                lightObject?.gameObject.SetActive(true);
            }

            if (collider != null)
                collider.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            key.Fallling();
        }
    }
}
