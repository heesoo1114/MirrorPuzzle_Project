using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Curtain : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private bool isOpen = false;

    public UnityEvent<int> OnTriggerIndex;

    private bool _enterCurtain = false;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetSortingLayer(bool playerEnter)
    {
        if (_enterCurtain) return;

        _spriteRenderer.sortingLayerName = playerEnter ? "F_NotLight" : "B_NotLight";
    }

    public void StartAnim()
    {
        isOpen = !isOpen;
        _animator.Play(isOpen ? "Open" : "Close");
    }

    public void TriggerAnimIndex(int num)
    {
        OnTriggerIndex?.Invoke(num);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _enterCurtain = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _enterCurtain = false;
        }
    }
}
