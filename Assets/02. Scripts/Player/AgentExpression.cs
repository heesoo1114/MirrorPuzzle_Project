using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentExpression : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _spriteRenderer.enabled = false;
    }

    public void ShowExpression(Sprite sprite)
    {
        _spriteRenderer.sprite = sprite;
        _spriteRenderer.enabled = true;

    }

    public void ReleaseExpression()
    {
        _spriteRenderer.enabled = false;

    }
}
