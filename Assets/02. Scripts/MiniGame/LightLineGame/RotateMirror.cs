using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateMirror : MonoBehaviour
{
    [SerializeField] private Sprite _leftSprite = null;
    [SerializeField] private Sprite _rightSprite = null;

    private SpriteRenderer _spriteRenderer= null;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public enum State
    {
        Left,
        Right
    }

    public State _state;

    private void Update()
    {
        if (_state == State.Left)
            _spriteRenderer.sprite = _leftSprite;
        else if (_state == State.Right)
            _spriteRenderer.sprite = _rightSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float rotation = 45f;
            switch (_state)
            {
                case State.Left:
                    rotation = 45f;
                    break;
                case State.Right:
                    rotation = -45f;
                    break;
            }
            collision.transform.Rotate(0,0,rotation);
        }
    }
}
